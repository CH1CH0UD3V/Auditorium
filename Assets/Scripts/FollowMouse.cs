using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    
    Vector2 _oldMousePosition;
    private void OnMouseDown()
    {
        Debug.Log("Tu as bien cliquer dessus");
        _oldMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        Debug.Log("Et ca se deplace, voici la magie du déplacement");
        Vector2 CurrentMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log($"MousePosition{Input.mousePosition} World {CurrentMousePosition}");
        transform.Translate(CurrentMousePosition - _oldMousePosition, Space.World);
        //FIN
        _oldMousePosition = CurrentMousePosition;
    }

    private void OnMouseUp()
    {
        Debug.Log("Tu viens de lâcher le bouton");
    }
}
