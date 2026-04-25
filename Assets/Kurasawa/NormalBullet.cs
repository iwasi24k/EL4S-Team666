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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
