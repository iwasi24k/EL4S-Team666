using System;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    [SerializeField] private GameObject _Player;

    [SerializeField] private GameObject _Bullet;

    private Renderer _Renderer;
    private bool     _LastFrameVisible = false;
    
    private Vector3 _MoveDirection = Vector3.zero;

    private float _BulletInterval = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Player =  GameObject.FindGameObjectWithTag("Player");
        _Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // 画面内に入ったとき
        if (_LastFrameVisible == false != _Renderer.isVisible) {
            _MoveDirection = new Vector2(transform.position.x - _Player.transform.position.x, transform.position.y - _Player.transform.position.y).normalized;
        }
        
        // 移動
        transform.position += _MoveDirection * EnemyManager._MoveSpeed;

        // 画面外に出たとき
        if (_LastFrameVisible == true != _Renderer.isVisible) {
            Destroy(this.gameObject);
        }
        
        _LastFrameVisible = _Renderer.isVisible;

        // 弾の発射処理
        _BulletInterval -= Time.deltaTime;
        if (_BulletInterval <= 0.0f) {
            var bullet = Instantiate(_Bullet, transform.position, transform.rotation);
            bullet.GetComponent<Bullet>().SetTarget(_Player.transform);
            _BulletInterval = EnemyManager._BulletInterval;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("PlayerBullet")) {
            Damage();
        }
    }

    private void Damage() {
        Destroy(this.gameObject);
    }

}
