using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] float _cooldown;
    float _cooldownRremaining;

    //cooldown sert de r�f�rence � cooldowRemain pour le compte � rebours.
    //au demmarage les deux se synchronise.
    //dans l'update deltatime se retire du compte � chaque rafraichisement de la frame, pour afficher un compte � rebours jusqu'� zero.
    // � la fin du compte � rebours une nouvelle sphere se cr�e.
    void Start()
    {
        _cooldownRremaining = _cooldown;

    }
 
    
    void Update()
    {

        _cooldownRremaining -= Time.deltaTime;
        Debug.Log(_cooldownRremaining);
        
        if (_cooldownRremaining < 0)
        {
             _cooldownRremaining = _cooldown;
            GameObject.Instantiate(_prefab, transform.position, transform.rotation);
        }
    }
}
