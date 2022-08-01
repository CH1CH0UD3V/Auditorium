using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReceiver : MonoBehaviour
{
    [SerializeField] int _bulletMax;
    [SerializeField] float _bulletDecrase;

    int _currentScore;
    float _lastShoot;
    //float _newShoot;

    void Start()
    {
        _currentScore = 0;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet_Movement bullet = collision.GetComponentInParent<Bullet_Movement>(); //on fait appel au script de bullet pour dire qu'en cas de collision avec il augmente les points sinon il ignore tout autre objet.
        //Debug.Log("oh ben merde un bullet m'est rentré dedans");
        if (bullet != null)
        {
            _lastShoot = Time.time;

            if(_currentScore < _bulletMax)
            {
            _currentScore += 1;
            Debug.Log($"Current score is {_currentScore} points");
            }
        }

    }
    void Update()
    {

        if (Time.time > _lastShoot + _bulletDecrase)
        {
            _currentScore --;
            Debug.Log($"Votre jauges perds des points, si vous ne shootez plus {_currentScore} points");

            if(_currentScore < 0)
            {
                _currentScore = Mathf.Max(_currentScore - 1, 0);
                Debug.Log($"Sourit tu es Dead {_currentScore}");
            }




        }
        
    }
}