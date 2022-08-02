using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReceiver : MonoBehaviour
{
    [SerializeField] int _bulletMax;
    [SerializeField] float _bulletDecrase;
    [SerializeField] Color _onSprite;
    [SerializeField] Color _offSprite;
    [SerializeField] SpriteRenderer[] _gauge;
    [SerializeField] float _reductionSpeedPerSeconds;


    float _currentScore;
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

            if (_currentScore < _bulletMax)
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
            _currentScore = Mathf.Max(_currentScore - (_reductionSpeedPerSeconds * Time.deltaTime), 0);
            Debug.Log($"Votre jauges perds des points, si vous ne shootez plus {_currentScore} points");

            if (_currentScore <= 0)
            {
                Debug.Log($"Sourit tu es Dead {_currentScore}");

            }

        }
        float percent = _currentScore / _bulletMax;
        float gaugeCompletion = percent * _gauge.Length;
        Debug.Log(gaugeCompletion);

        for (int i = 0; i < _gauge.Length; i++)
        {
            if (i < gaugeCompletion)
            {
                _gauge[i].color = _onSprite;
            }
            else
            {
                _gauge[i].color = _offSprite;
            }
        }


    }
}