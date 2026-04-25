using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private PlayerStatusController status;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] float cooldown;

    private float timer;

    private void Awake()
    {
        status = GetComponent<PlayerStatusController>();
        

        if (status == null) Debug.LogError("PlayerStatusController������܂���", this);
    }

    void Update()
    {
        timer += Time.deltaTime;

        status.Cooldown -= Time.deltaTime;
        if (status.Cooldown > 0) return;
        
        Shoot();
        status.Cooldown = cooldown;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}