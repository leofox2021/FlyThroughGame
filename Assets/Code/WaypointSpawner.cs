using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All

public class WaypointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private List<GameObject> _waypointList = new List<GameObject>();
    public List<GameObject> WaypointList
    {
        get
        {
            return _waypointList;
        }
    }
    public int WaypointCount
    {
        get
        {
            return _waypointList.Count;
        }
    }


    public void GenerateWaypoint()
    {
        GameObject newObject = Instantiate(_prefab);
        _waypointList.Add(gameObject);
    }
}
