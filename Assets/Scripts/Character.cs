using UnityEngine;

public abstract class Character : MonoBehaviour
{
    //attributes
    private int health;
    public int Health
    {
        get => health; 
        set => health = (value < 0) ? 0 : value;
    }

    protected Animator anim;
    protected Rigidbody2D rb;

    //initialize character
    public void Initialize(int startHealth)
    {

    }

    //Behavior
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} takes damage {damage}. Current Health : {Health}");
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else { return false; }
    }

    void Start()
    {

    }
}
