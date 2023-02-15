using UnityEngine;
using static Database.Lists;

// ReSharper disable All

public class Waypoint : MonoBehaviour
{
    private void Start()
    {
        Waypoints.Add(this);
        Debug.Log("New waypoint is created and added to the list!");
        Debug.Log($"List count is now {Waypoints.Count}");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plane")
            Destroy(gameObject);
    }
}
