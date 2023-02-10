using System;
using System.Collections.Generic;
using Database;
using UnityEngine;

// ReSharper disable All

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private int _distanceBetweenClouds;

    private List<GameObject> cloudsInField = new List<GameObject>();
    private System.Random random = new System.Random();

    
    public void Start()
    {
        initialSpawn();
    }


    public void Update()
    {
        spawnInactive();
    }

    
    public void spawnInactive()
    {
        foreach (GameObject cloud in CloudPool.Instance.pool)
        {
            if (!cloud.activeInHierarchy)
            {
                float randomX = random.Next(Constants.MapBoundaryX1, Constants.MapBoundaryX2);
                Vector3 newPosition = new Vector3(randomX, Constants.Height, Constants.MapBoundaryZ2);
                
                cloud.transform.position = newPosition;
                cloud.SetActive(true);
            }
        }    
    }
    
    
    public void initialSpawn()
    {
        CloudPool.Instance.generateClouds();
        Debug.Log("All clouds have been spawned!");
        
        foreach (GameObject cloud in CloudPool.Instance.pool)
        {
            Vector3 position = generatePosition(cloud);
            
            cloud.transform.position = position;
            cloud.SetActive(true);
        }
    }
    
    
    private Vector3 generatePosition(GameObject cloud)
    {
        Vector3 randomSpawnPosition = new Vector3();
        bool wrongPosition = true;
        
        while (true)
        {
            foreach (GameObject otherCloud in CloudPool.Instance.pool)
            {
                float randomX = random.Next(Constants.MapBoundaryX1, Constants.MapBoundaryX2);
                float randomZ = random.Next(Constants.MapBoundaryZ1, Constants.MapBoundaryZ2);
            
                randomSpawnPosition = new Vector3(randomX, Constants.Height, randomZ);
            
                float distance = Vector3.Distance(randomSpawnPosition, otherCloud.transform.position);
                
                if (distance > 100)
                {
                    wrongPosition = false;
                    Debug.Log($"Distance RIGHT {distance}");
                } 
                else
                {
                    wrongPosition = true;
                    Debug.Log($"Distance WRONG {distance}");
                    break;
                }
            }

            if (wrongPosition == false) break;
        }

        return randomSpawnPosition;
    }
}
