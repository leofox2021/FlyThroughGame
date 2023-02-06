using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Database;
// ReSharper disable All

public class PlaneMove : MonoBehaviour 
{
    [SerializeField] private Rigidbody airplane;
    [SerializeField] private float _speed;

    private Vector3 direction;
    private bool _moving;

    public void Start() 
    {
        _moving = false;
    }

    
    public void Update() 
    {
        // Start / stop
        if (Input.GetKey(Keys.startKey)) _moving = true;
        else if (Input.GetKey(Keys.stopKey)) _moving = false;
    }

    
    public void FixedUpdate() {
        if (_moving) 
        {
            direction = new Vector3(0, 0, 1);
            moveAirplane(direction, "The plane is now moving");   
        }   
        else 
        {
            direction = new Vector3(0, 0, 0);
            moveAirplane(direction, "The plane has stopped moving");
        }
    }
    
    
    private void moveAirplane(Vector3 direction, string debugMessage) 
    {
        airplane.velocity = direction * _speed;
        Debug.Log(debugMessage);
    }
}