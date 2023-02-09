using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All

public class WaypointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private List<GameObject> waypointList = new List<GameObject>();
    public List<GameObject> WaypointList
    {
        get
        {
            return waypointList;
        }
    }
    public int WaypointCount
    {
        get
        {
            return waypointList.Count;
        }
    }


    public void generateWaypoint()
    {
        GameObject newObject = Instantiate(prefab);
        waypointList.Add(gameObject);
    }
}
