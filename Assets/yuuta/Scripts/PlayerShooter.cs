using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private PlayerStatusController status;

    [SerializeField] private GameObject bulletPrefab;
    private float cooldown;

    private float timer;

    private void Awake()
    {
        status = GetComponent<PlayerStatusController>();
        cooldown = status.Cooldown;

        if (status == null) Debug.LogError("PlayerStatusController‚ª‚ ‚è‚Ü‚¹‚ñ", this);
    }

    void Update()
    {
        timer += Time.deltaTime;

        status.Cooldown -= Time.deltaTime;
        if (status.Cooldown >= 0) return;
        
        Shoot();
        status.Cooldown = cooldown;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}