using System;
using System.Collections;
using System.Collections.Generic;
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
            _moving = true;
        }
        else if (Input.GetKey(Keys.stopKey))
        {
            direction.Set(0, 0, 0);
            _moving = false;
        }
        
        if (Input.GetKey(Keys.rightKey))
        {
            if (currentZ < _peakRotation)
            {
                _rotating = true;
                rotation.Set(_rotationStep / 10, currentY, -_rotationStep);
            }
        }
        else if (Input.GetKey(Keys.leftKey))
        {
            if (currentZ > -_peakRotation)
            {
                _rotating = true;
                rotation.Set(_rotationStep / 10, currentY, _rotationStep);
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
        if (_moving)
            airplane.MovePosition(
                airplane.transform.position + 
                airplane.transform.forward * 
                _movementSpeed * 
                Time.deltaTime
            );
        else {}

        if (_rotating)
            rotateAirplane(rotation);
    }
    
    
    private void rotateAirplane(Vector3 eulerAngles)
    {
        airplane.transform.Rotate(rotation, Space.Self);;
        _rotating = false;
    }
}