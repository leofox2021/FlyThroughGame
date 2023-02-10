using UnityEngine;

// ReSharper disable All

public class PlaneMove : MonoBehaviour 
{
    [SerializeField] private Rigidbody _airplane;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationStep;
    [SerializeField] private float _peakRotation;
    
    private Vector3 _direction;
    private Vector3 _rotation;
    
    private bool _moving;
    private bool _rotating;

    private void Start() 
    {
        _moving = false;
        _direction.Set(0, 0, 0.5f);
    }


    private void FixedUpdate()
    {
        Vector3 currentPosition = _airplane.transform.position;
        Vector3 forwardDirection = _airplane.transform.forward;
        
        if (_moving)
            _airplane.MovePosition(currentPosition + (forwardDirection * _movementSpeed * Time.deltaTime));
        
        if (_rotating) RotateAirplane(_rotation);
    }
    
    
    public void SetMovingOn()
    {
        _moving = true;
    }
    
    
    public void SetMovingOff()
    {
        _direction.Set(0, 0, 0);
        _moving = false;
    }
    
    
    private void RotateAirplane(Vector3 eulerAngles)
    {
        _airplane.transform.Rotate(_direction, Space.Self);;
        _rotating = false;
    }
}