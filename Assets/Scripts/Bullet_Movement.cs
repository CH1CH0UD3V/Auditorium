using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] Vector2 _direction;
    void Start()
    {
        _rb.velocity = _direction * _speed;
    }
}
