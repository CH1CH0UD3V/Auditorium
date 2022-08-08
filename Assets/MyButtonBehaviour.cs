using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MyButtonBehaviour : MonoBehaviour
{
    [SerializeField] Button _buttonToControl;
    
    [SerializeField] UnityEvent _onPressed;
    [SerializeField] UnityEvent _onReleased;

    bool _isPressed;

    // Start is called before the first frame update
    void Start()
    {
        _buttonToControl.onClick.AddListener(MaFonction);
    }

    // Update is called once per frame
    void MaFonction()
    {
        //1-Change internal state
        //_isPressed = !_isPressed (la maniere de faire habituelle)
        if (_isPressed == true)
        {
            _isPressed = false;
        }
        else if (_isPressed == false)
        {
            _isPressed = true;
        }

        //2-Call our events
        if (_isPressed)
        {
            _onPressed.Invoke();
        }
        if (_isPressed)
        {
            _onReleased.Invoke();
        }
    }
}
