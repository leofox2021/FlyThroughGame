using UnityEngine;

// ReSharper disable All

public class MouseDrag : MonoBehaviour
{
    private Vector3 _offset;
    private float _mouseCoordinateZ;
    
    
    private void OnMouseDrag()
    {
        transform.position = getMousePosition() + _offset;
    }


    private void OnMouseDown()
    {
        _mouseCoordinateZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        _offset = gameObject.transform.position - getMousePosition();
    }

    
    private Vector3 getMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _mouseCoordinateZ;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}