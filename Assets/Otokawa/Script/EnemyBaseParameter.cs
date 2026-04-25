using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBaseParameter", menuName = "Scriptable Objects/EnemyBaseParameter")]
public class EnemyBaseParameter : ScriptableObject
{
    public float _MoveSpeed { get; }
    public float _BulletInterval { get; }
    public float _BulletSize { get; }
    public float _HitBoxSize { get; }
}
