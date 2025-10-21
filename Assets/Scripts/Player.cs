using UnityEngine;

public class Player : Character
{
    void Start()
    {
        base.Initialize(100); //set health for player
    }

    void Update()
    {
        
    }

    public void OnHitWith(Enemy enemy)
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null) {
            Debug.Log($"{this.name} Hit with {enemy.name}!");
            OnHitWith(enemy);
        }
    }
}
