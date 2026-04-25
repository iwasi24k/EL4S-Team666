using UnityEngine;

public class NormalBullet : Bullet
{
    void Start()
    {
        if (target != null)
        {
            direction = (target.position - transform.position).normalized;
        }
        else
        {
            direction = direction.normalized;
        }
    }
    void Update()
    {
        if(changed)
        {
            if (target != null)
            {
                direction = (target.position - transform.position).normalized;
            }
            else
            {
                direction = direction.normalized;
            }
            changed = false;
        }
       
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isPlayer && collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        else if (!isPlayer && collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        
    }

}
