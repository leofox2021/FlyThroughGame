using UnityEngine;
using Database;
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

    
    public void Update()
    {
        float currentX = airplane.transform.rotation.x;
        float currentY = airplane.transform.rotation.y;
        float currentZ = airplane.transform.rotation.z;
        
        if (Input.GetKey(Keys.startKey))
        {
            setMovingOn();
        }
        else if (Input.GetKey(Keys.stopKey))
        {
            setMovingOff();
        }
        
        if (Input.GetKey(Keys.rightKey))
        {
            if (currentZ < _peakRotation)
            {
                _rotating = true;
                rotation.Set(currentX, _rotationStep / 4, -_rotationStep);
            }
        }
        else if (Input.GetKey(Keys.leftKey))
        {
            if (currentZ > -_peakRotation)
            {
                _rotating = true;
                rotation.Set(currentX, -_rotationStep / 4, _rotationStep);
            }
        }
        
        if (Input.GetKey(Keys.upkey))
        {
            if (currentX > -_peakRotation)
            {
                _rotating = true;
                rotation.Set(_rotationStep, currentY, currentZ);
            }
            
        }
        else if (Input.GetKey(Keys.downKey))
        {
            if (currentX < _peakRotation)
            {
                _rotating = true;
                rotation.Set(-_rotationStep, currentY, currentZ);
            }
        }
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