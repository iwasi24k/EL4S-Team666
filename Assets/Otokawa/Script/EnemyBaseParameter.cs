using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBaseParameter", menuName = "Scriptable Objects/EnemyBaseParameter")]
public class EnemyBaseParameter : ScriptableObject {
	[SerializeField] private float _moveSpeed;
	[SerializeField] private float _bulletInterval;
	[SerializeField] private float _bulletSize;
	[SerializeField] private float _hitBoxSize;
	[SerializeField] private float _bulletSpeed;

	public float _MoveSpeed => _moveSpeed;
	public float _BulletInterval => _bulletInterval;
	public float _BulletSize => _bulletSize;
	public float _HitBoxSize => _hitBoxSize;
	public float _BulletSpeed => _bulletSpeed;
}
