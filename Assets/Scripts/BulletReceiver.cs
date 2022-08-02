using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletReceiver : MonoBehaviour
{
    [SerializeField] int _bulletMax;
    [SerializeField] float _waitBulletBeforeDecrease;
    [SerializeField] Color _onSprite;
    [SerializeField] Color _offSprite;
    [SerializeField] SpriteRenderer[] _gauge;
    [SerializeField] float _reductionSpeedPerSeconds;


    [Header("Audio")]
    [SerializeField] AudioSource _audio;


    [Header("GainEffect")]
    [SerializeField] UnityEvent _onBulletReceived;
    [SerializeField] UnityEvent _objectifFinished;
    //[SerializeField] UnityEvent _levelFinished;


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
            float oldScore = _currentScore; // 10

            if(_currentScore < _bulletMax)
            {
                _currentScore += 1;         // 11
                Debug.Log($"Current score is {_currentScore} points");

                if (oldScore < _bulletMax && _currentScore >= _bulletMax)       
                {
                    _objectifFinished.Invoke();
                }
                else
                {
                    _onBulletReceived.Invoke();    
                }

            }
        }

    }
    void Update()
    {

        if (Time.time > _lastShoot + _waitBulletBeforeDecrease)
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
        _audio.volume = percent;


    }
}





//objectif 1 rempli
//detruire l'objet fini
    //objectif 2 rempli
    //detruire l'objet fini
        //objectif 3 rempli
        //detruire l'objet fini