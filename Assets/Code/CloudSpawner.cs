using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// ReSharper disable All

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _mapBoundaryX1;
    [SerializeField] private int _mapBoundaryX2;
    [SerializeField] private int _mapBoundaryZ1;
    [SerializeField] private int _mapBoundaryZ2;
    [SerializeField] private int _distanceBetweenClouds;

    private List<GameObject> cloudsInField = new List<GameObject>();
    private System.Random random = new System.Random();

    
    public void Start()
    {
        initialSpawn();
    }
    
    
    public void initialSpawn()
    {
        ObjectPool.Instance.generateClouds();
        Debug.Log("All clouds have been spawned!");
        
        foreach (GameObject cloud in ObjectPool.Instance.pool)
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
        int iteration; 
        
        while (true)
        {
            iteration = 1;
            
            foreach (GameObject otherCloud in ObjectPool.Instance.pool)
            {
                iteration += 1;
                Debug.Log($"Iteration number {iteration}");
                
                float randomX = random.Next(_mapBoundaryX1, _mapBoundaryX2);
                float randomZ = random.Next(_mapBoundaryZ1, _mapBoundaryZ2);
            
                randomSpawnPosition = new Vector3(randomX, _height, randomZ);
            
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
