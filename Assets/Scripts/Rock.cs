using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rb; //show this in Unity
    public Vector2 force; // use to throw Rock

    public override void Move()
    {
        //use physics in Unity (RigidBody2D) to add force to throw Rock
        rb.AddForce(force);
    }

    public override void OnHitWith(Character obj)
    {
        if (obj is Player)
        {
            obj.TakeDamage(this.damage);
        }
    }

    void Start()
    {
        damage = 40;
        force = new Vector2(GetShooterDirection() * 90, 400);
        Move(); //Add force to rock immediately once created
    }

    void Update()
    {
        
    }
}
