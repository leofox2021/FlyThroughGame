using UnityEngine;

// ReSharper disable All

public class PlaneMove : MonoBehaviour 
{
    [SerializeField] private Rigidbody airplane;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationStep;
    [SerializeField] private float _peakRotation;
    
    
    private Vector3 direction;
    private Vector3 rotation;
    
    private bool _moving;
    private bool _rotating;

    public void Start() 
    {
        _moving = false;
        direction.Set(0, 0, 0.5f);
    }


    public void FixedUpdate()
    {
        Vector3 currentPosition = airplane.transform.position;
        Vector3 forwardDirection = airplane.transform.forward;
        
        if (_moving)
            airplane.MovePosition(currentPosition + forwardDirection * _movementSpeed * Time.deltaTime);
        
        if (_rotating) rotateAirplane(rotation);
    }
    
    
    public void setMovingOn()
    {
        _moving = true;
    }
    
    
    public void setMovingOff()
    {
        direction.Set(0, 0, 0);
        _moving = false;
    }
    
    
    private void rotateAirplane(Vector3 eulerAngles)
    {
        airplane.transform.Rotate(rotation, Space.Self);;
        _rotating = false;
    }
}