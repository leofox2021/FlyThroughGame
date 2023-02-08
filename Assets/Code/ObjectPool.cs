using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int _amountToPool;

    private static ObjectPool instance;
    public static ObjectPool Instance
    {
        get { return instance; }
        set { instance = new ObjectPool(); }
    }
    
    public List<GameObject> pool = new List<GameObject>();

    private bool _filling = true;
    public bool Filling
    {
        get { return _filling;  }
    }

    
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    
    public void Start()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.SetActive(false);
            pool.Add(newObject);
            
            Debug.Log($"Cloud number {i} has been spawned");
        }

        _filling = false;
    }
    
    
    public GameObject getPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return null;
    } 
}