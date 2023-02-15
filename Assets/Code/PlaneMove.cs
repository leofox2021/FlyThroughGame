using System;
using System.Linq;
using Database;
using UnityEngine;

// ReSharper disable All

public class PlaneMove : MonoBehaviour 
{
    [SerializeField] private Rigidbody _airplane;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationStep;
    [SerializeField] private float _peakRotation;

    private Waypoint _headedTowards = null;
    public Waypoint HeadedTowards
    {
        get
        {
            return _headedTowards;
        }
    }
    
    private Vector3 _direction;
    private Vector3 _rotation;
    private Vector3 _targetPosition;
    private Vector3 _currentPosition;
    
    private bool _moving;
    private bool _rotating;

    
    private void Start() 
    {
        _moving = false;
        _direction = _airplane.transform.forward;
    }


    private void Update()
    {
        _currentPosition = _airplane.transform.position;
        _direction = _airplane.transform.forward;
    }

    
    private void FixedUpdate()
    {
        if (_moving)
            _airplane.MovePosition(_currentPosition + (_direction * _movementSpeed * Time.deltaTime));
        
        if (_rotating) RotateAirplane(_rotation);
    }


    public void SetMovingOn()
    {
        SetInitialHeading();
        _moving = true;
    }
    
    
    public void SetMovingOff()
    {
        _moving = false;
    }
    
    
    private void SetInitialHeading()
    {    
        // If no waypoint passed 
        if (Lists.Waypoints.Count != 0 && _headedTowards == null) 
        {
            _headedTowards = Lists.Waypoints[0];
            _targetPosition = Lists.Waypoints[0].gameObject.transform.position;
            _airplane.transform.LookAt(_targetPosition);
        }
    }
    
    
    public void OnWaypointPass()
    {
        // If there are more waypoints to pass
        for (int i = 0; i < Lists.Waypoints.Count; i++)
        {
            if (Lists.Waypoints[i] == _headedTowards)
            {
                Debug.Log($"Switching to waypoint {i + 1}");
                
                _headedTowards = Lists.Waypoints[i + 1];
                _targetPosition = Lists.Waypoints[i + 1].gameObject.transform.position;
                _airplane.transform.LookAt(_targetPosition);
                return;
            }            
        }
    }

    
    private void RotateAirplane(Vector3 eulerAngles)
    {
        _airplane.transform.Rotate(_direction, Space.Self);;
        _rotating = false;
    }
}