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

    private void FixedUpdate()
    {
        Behavior();
    }
    
    public void Update()
    {
        
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        //Move left
        if (velocity.x < 0 && transform.position.x < movePoints[0].position.x)
        {
            Flip();
        }
        //Move right
        if (velocity.x > 0 && transform.position.x > movePoints[1].position.x)
        {
            Flip();
        }
    }

    public void Flip()
    {
        velocity.x *= -1; //change direction

        //flip the sprite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
