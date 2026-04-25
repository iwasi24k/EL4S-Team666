using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField]
    private EnemyBaseParameter _parameter;
    
    public static float _MoveSpeed      { get; private set; }
    public static float _BulletSpeed      { get; private set; }
    public static float _BulletSize     { get; private set; }
    public static float _BulletInterval { get; private set; }
    public static float _HitBoxSize     { get; private set; }
    public static float _Alpha          { get; private set; }

    void Start() {
        _MoveSpeed      = _parameter._MoveSpeed;
        _BulletSpeed    = _parameter._BulletSpeed;
        _BulletSize     = _parameter._BulletSize;
        _BulletInterval = _parameter._BulletInterval;
        _HitBoxSize     = _parameter._HitBoxSize;
        _Alpha          = 1.0f;
    }

    public void SetMoveSpeed(float scale) {
        _MoveSpeed = scale * _parameter._MoveSpeed;
    }

    public void SetBulletSize(float bulletSize) {
        _BulletSize = bulletSize *  _parameter._BulletSize;
    }

    public void SetBulletInterval(float bulletInterval) {
        _BulletInterval = bulletInterval * _parameter._BulletInterval;
    }

    public void SetHitBoxSize(float bulletSize) {
        _HitBoxSize = bulletSize * _parameter._HitBoxSize;
    }

    public void SetAlpha(float alpha) {
        _Alpha = alpha;
    }
}
