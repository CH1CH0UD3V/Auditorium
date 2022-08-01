using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _cooldown;
    [SerializeField] float _min;
    [SerializeField] float _max;
    [SerializeField] float _multiplicator = 1;
    [SerializeField] Color _gizmoColor;


    float _lastShoot;
    void Update()
    {
        float rx = Random.Range(_min, _max);
        float ry = Random.Range(_min, _max);
        Vector3 randomDirection = new Vector3(rx, ry) * _multiplicator;
        //Vector3 randomDirection = Random.insideUnitCircle * _multiplicator;
        if (Time.time > _lastShoot + _cooldown)
        {
            _lastShoot =Time.time;
            GameObject.Instantiate(_bulletPrefab, transform.position + randomDirection, transform.rotation);

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = _gizmoColor;
        Gizmos.DrawCube(transform.position, new Vector3(_multiplicator*2, _multiplicator*2, _multiplicator*2));
    }

}
