using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Game/Player Status")]
public class PlayerStatus : ScriptableObject
{
    [Header("Player Stats")]
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float cooldown = 1f;

    public int MaxHealth => maxHealth;
    public float Speed => speed;
    public float Cooldown => cooldown;
}
