using UnityEngine;
using static Database.Keys;

// ReSharper disable All

public class KeyboardController : MonoBehaviour
{
    [SerializeField] private PlaneMove _plane;
    [SerializeField] private WaypointSpawner _waypointSpawner;
    
    private void Update()
    {
        if (Input.GetKey(StartMovingKey))
        {
            _plane.SetMovingOn();
            Debug.Log($"{StartMovingKey} pressed");
        }
        else if (Input.GetKey(StopMovingKey))
        {
            _plane.SetMovingOff();
            Debug.Log($"{StopMovingKey} pressed");
        }
        else if (Input.GetKey(NewWaypointKey))
        {
            if (!_waypointSpawner.Cooldown)
                _waypointSpawner.GenerateWaypoint();
            
            Debug.Log($"{NewWaypointKey} pressed");
        }
    }
}
