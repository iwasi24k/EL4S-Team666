using UnityEngine;

public class PlayerHitCheck : MonoBehaviour
{
    private PlayerStatusController status;
    [SerializeField] private float damageCooldown = 1f;
    private float damageInterval;

    private void Awake()
    {
        status = GetComponent<PlayerStatusController>();
        damageInterval = damageCooldown;

        if (status == null) Debug.LogError("PlayerStatusController‚ª‚ ‚è‚Ü‚¹‚ñ", this);
    }

    private void Update()
    {
        damageInterval -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageInterval >= 0) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            var status = GetComponent<PlayerStatusController>();
            if (status != null)
            {
                status.Health--;
                damageInterval = damageCooldown;
            }
        }

        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            var status = GetComponent<PlayerStatusController>();
            if (status != null)
            {
                status.Health--;
                damageInterval = damageCooldown;
            }
        }
    }
}
