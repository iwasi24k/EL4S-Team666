using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;

    private int health;
    private float speed;
    private float cooldown;

    private void Awake()
    {
        health = status.MaxHealth;
        speed = status.Speed;
        cooldown = status.Cooldown;
    }

    private void Update()
    {
        if(health < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public int Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, status.MaxHealth);
    }
    public float Speed
    {        
        get => speed;
        set => speed = Mathf.Max(0, value);
    }

    public float Cooldown
    {
        get => cooldown;
        set => cooldown = Mathf.Max(0, value);
    }
}
