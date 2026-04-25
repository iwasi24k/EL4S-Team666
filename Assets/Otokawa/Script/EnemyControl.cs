using System;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    [SerializeField] private GameObject _Player;

    [SerializeField] private GameObject _Bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Player =  GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("EnemyBullet")) {
            Damage();
        }
    }

    private void Damage() {
        Destroy(this.gameObject);
    }

}
