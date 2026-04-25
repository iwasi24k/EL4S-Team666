using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    private PlayerStatusController status;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] float cooldown;

    private Camera cam;

    private void Awake()
    {
        status = GetComponent<PlayerStatusController>();
        cam = Camera.main;

        if (status == null) Debug.LogError("PlayerStatusController������܂���", this);
        if (cam == null) Debug.LogError("MainCameraがありません", this);
    }

    void Update()
    {
        status.Cooldown -= Time.deltaTime;
        if (status.Cooldown > 0) return;
        
        Shoot();
        status.Cooldown = cooldown;
    }

    void Shoot()
    {
        // マウス → ワールド座標
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        // 方向
        Vector2 dir = (worldPos - transform.position).normalized;

        // 回転
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0, 0, angle);

        // 生成
        GameObject obj = Instantiate(bulletPrefab, transform.position, rot);

        // 弾に方向を渡す（任意）
        obj.GetComponent<Bullet>().SetDirection(dir);
    }
}