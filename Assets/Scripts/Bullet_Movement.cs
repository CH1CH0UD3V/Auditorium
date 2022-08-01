using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] Vector2 _direction;
    [SerializeField] float _bulletDuration;

        float _starLife;

    void Start()
    {

        _rb.velocity = _direction * _speed;
        _starLife = Time.time;
    }
    void Update()
    {
        if (Time.time > _starLife + _bulletDuration)
        {
            GameObject.Destroy(gameObject);
        }
        
    }
}
