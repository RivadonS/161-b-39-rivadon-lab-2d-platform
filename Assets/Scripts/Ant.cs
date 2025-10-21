using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity;
    public Transform[] movePoints;

    void Start()
    {
        base.Initialize(20);
        DamageHit = 20;

        //set speed and direction of movement
        velocity = new Vector2(-1.0f, 0.0f); //move left first
    }

    void Update()
    {
        
    }

    public override void Behavior()
    {
        throw new System.NotImplementedException();
    }
}
