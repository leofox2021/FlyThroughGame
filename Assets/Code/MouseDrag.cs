using UnityEngine;

// ReSharper disable All

public class MouseDrag : MonoBehaviour
{
    private Vector3 offset;
    private float _mouseCoordinateZ;
    
    
    public void OnMouseDrag()
    {
        transform.position = getMousePosition() + offset;
    }


    public void OnMouseDown()
    {
        _mouseCoordinateZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - getMousePosition();
    }

    
    public Vector3 getMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _mouseCoordinateZ;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}