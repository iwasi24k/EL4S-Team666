using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LaserBullet : Bullet
{
    private float currentLength = 0f;
    [SerializeField] private float maxLength = 5f;
    [SerializeField] private float growthSpeed = 10f;
    [Header("伸びている間だけ速度が場合により\n少し遅く見えるので補正用に掛ける値\n(maxLengthやgrowthSpeedによって要調整)")]
    [SerializeField] private float adjustSpeed = 1.5f;
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.localScale = new Vector3(0, transform.localScale.y, 1);
    }
    void Update()
    {
        float TotalSpeed = speed;
        if (changed)
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
        if(currentLength >= maxLength)
        {
            currentLength = maxLength;
        }
        else
        {
            currentLength += growthSpeed * Time.deltaTime * adjustSpeed;
        }
        currentLength += speed * Time.deltaTime;

        // スケールに適用（X方向に伸びる設定の場合）
        transform.localScale = new Vector3(currentLength, transform.localScale.y, 1);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
