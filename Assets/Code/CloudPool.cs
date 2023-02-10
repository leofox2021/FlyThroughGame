using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All

public class CloudPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _amountToPool;

    private static CloudPool _instance;
    public static CloudPool Instance { get { return _instance; } }

    public List<GameObject> Pool = new List<GameObject>();
    
    
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }


    public void GenerateClouds()
    {
        if (this.Pool.Count == 0)
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                GameObject newObject = Instantiate(_prefab);
                newObject.SetActive(false);
                Pool.Add(newObject);
            } 
        }
    }
}