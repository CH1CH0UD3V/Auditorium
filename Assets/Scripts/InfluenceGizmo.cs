using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluenceGizmo : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] CircleCollider2D _areaCircle;
    [SerializeField] AreaEffector2D _areaEffector;
    
    Vector2 _oldMousePosition;

    private void OnMouseDown()
    {
        _oldMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Tu as bien cliquer dessus");
    }
    private void OnMouseDrag()
    {
        Debug.Log("Et ca se deplace, voici la magie du déplacement");
        Vector2 CurrentMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position2D = transform.position;
        float distance = Vector2.Distance(position2D, CurrentMousePosition);

        Debug.Log($"Origin Position{position2D}");
        Debug.Log($"Cursor Position{CurrentMousePosition}");
        Debug.Log($"Distance{distance}");

        _areaCircle.radius = distance * 0.5f;
       
        //FIN
        _oldMousePosition = CurrentMousePosition;
    }

    private void OnMouseUp()
    {
        Debug.Log("Tu viens de lâcher le bouton");
    }
}
