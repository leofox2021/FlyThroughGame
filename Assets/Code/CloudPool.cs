using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All

public class CloudPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int _amountToPool;

    private static CloudPool instance;
    public static CloudPool Instance { get { return instance; } }
    
    public List<GameObject> pool = new List<GameObject>(){};
    
    
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void generateClouds()
    {
        if (this.pool.Count == 0)
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                GameObject newObject = Instantiate(prefab);
                newObject.SetActive(false);
                pool.Add(newObject);
                
                Debug.Log($"Cloud number {i} has been spawned!");
            } 
        }
        else
        {
            Debug.Log("Your clouds are already generated!");
        }
    }
}