using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField]  float atkRange;
    public Player player;

    void Start()
    {
        base.Initialize(50); //set health for crocodile
        DamageHit = 30;

        //set atk range and target
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
    }

    public void FixedUpdate()
    {
        
    }
    
    public void Update()
    {
        Behavior();
    }

    public override void Behavior()
    {
        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player} is in the {this.name}'s attack range!");
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log($"{this.name} shoots rock to the {player.name}");
    }
}
