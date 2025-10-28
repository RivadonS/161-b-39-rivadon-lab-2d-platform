using UnityEngine;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    [field: SerializeField] public float ReloadTime { get; set;}
    [field: SerializeField] public float WaitTime { get; set;}

    void Start()
    {
        base.Initialize(100); //set health for player
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
    }

    private void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if ( Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
            {
                banana.InitWeapon(20, this);
            }

            WaitTime = 0.0f; //reset waitTime
        }
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null) {
            OnHitWith(enemy);
            Debug.Log($"{this.name} collides with {enemy.name}!");
        }
    }
}
