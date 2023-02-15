using System.Linq;
using UnityEngine;
using static Database.Lists;

// ReSharper disable All

public class PlaneCollider : MonoBehaviour
{
    [SerializeField] private PlaneMove _planeParent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            if (_planeParent.HeadedTowards == Waypoints.Last())
            {
                _planeParent.SetMovingOff();
                Debug.Log("Last waypoint reached");
            }
            else 
            {
                Debug.Log("Moving to next waypoint...");
                _planeParent.OnWaypointPass();
            }
        }
    }
}
