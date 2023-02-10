using System.Collections.Generic;
using Database;
using UnityEngine;

// ReSharper disable All

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private int _distanceBetweenClouds;

    private List<GameObject> _cloudsInField = new List<GameObject>();
    private System.Random _random = new System.Random();

    
    public void Start()
    {
        InitialSpawn();
    }


    public void Update()
    {
        SpawnInactive();
    }

    
    private void SpawnInactive()
    {
        foreach (GameObject cloud in CloudPool.Instance.Pool)
        {
            if (!cloud.activeInHierarchy)
            {
                float randomX = _random.Next(Constants.MapBoundaryX1, Constants.MapBoundaryX2);
                Vector3 newPosition = new Vector3(randomX, Constants.Height, Constants.MapBoundaryZ2);
                
                cloud.transform.position = newPosition;
                cloud.SetActive(true);
            }
        }    
    }
    
    
    private void InitialSpawn()
    {
        CloudPool.Instance.GenerateClouds();
        
        foreach (GameObject cloud in CloudPool.Instance.Pool)
        {
            Vector3 position = GeneratePosition(cloud);
            
            cloud.transform.position = position;
            cloud.SetActive(true);
        }
    }
    
    
    private Vector3 GeneratePosition(GameObject cloud)
    {
        Vector3 randomSpawnPosition = new Vector3();
        bool wrongPosition = true;
        
        while (true)
        {
            foreach (GameObject otherCloud in CloudPool.Instance.Pool)
            {
                float randomX = _random.Next(Constants.MapBoundaryX1, Constants.MapBoundaryX2);
                float randomZ = _random.Next(Constants.MapBoundaryZ1, Constants.MapBoundaryZ2);
            
                randomSpawnPosition = new Vector3(randomX, Constants.Height, randomZ);
            
                float distance = Vector3.Distance(randomSpawnPosition, otherCloud.transform.position);
                
                if (distance > _distanceBetweenClouds)
                {
                    wrongPosition = false;
                } 
                else
                {
                    wrongPosition = true;
                    break;
                }
            }

            if (wrongPosition == false) break;
        }

        return randomSpawnPosition;
    }
}
