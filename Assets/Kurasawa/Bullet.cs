using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public bool isPlayer = false;
    [SerializeField] protected Vector2 direction;
    [SerializeField] protected Transform target;
    protected bool changed = false;
    protected bool isLaser = false;


    public void SetTarget(Transform tar)
    {
        target = tar;
        direction = (target.position - transform.position).normalized;
        changed = true;
    }
    public void SetDirection(Vector2 dir)
    {
        target = null;
        direction = dir.normalized;
        changed = true;
    }
    public void SetIsPlayer(bool player)
    {
        isPlayer = player;
    }
    public void SetIsLaser(bool laser)
    {
        isLaser = laser;
    }
    public bool GetIsLaser()
    {
        return isLaser;
    }
    public void SetDestroy()
    {
       Destroy(gameObject);
    }
}
