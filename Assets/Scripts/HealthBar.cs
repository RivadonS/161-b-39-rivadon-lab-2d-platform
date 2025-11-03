using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthFillImage;

    [SerializeField] private Character targetCharacter;

    private void Awake()
    {
        if (targetCharacter == null)
        {
            targetCharacter = GetComponentInParent<Character>();
        }
    }

    private void Start()
    {
        if (targetCharacter == null)
        {
            Debug.LogWarning("HealthBar: No Target Character!");
            gameObject.SetActive(false);
            return;
        }

        if (healthFillImage == null)
        {
            Debug.LogWarning("HealthBar: Please put Image to healthFillImage!");
            gameObject.SetActive(false);
            return;
        }

        targetCharacter.OnHealthChanged += HandleHealthChanged;

        healthFillImage.fillAmount = (float)targetCharacter.Health / (float)targetCharacter.MaxHealth;
    }

    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
        float fillPercentage = (float)currentHealth / (float)maxHealth;

        healthFillImage.fillAmount = fillPercentage;
    }

    private void OnDestroy()
    {
        if (targetCharacter != null)
        {
            targetCharacter.OnHealthChanged -= HandleHealthChanged;
        }
    }
}
