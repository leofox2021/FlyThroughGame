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

    
    public void Update()
    {
    
    }
    
    
    public async void initialSpawn()
    {
        // No async function can use with unity methods
        // Thus it is useless here
        // But is used to delay the run of initialSpawn and let clouds spawn
        await Task.Run(() =>
        {
       
        });

        
        foreach (GameObject cloud in ObjectPool.Instance.pool)
        {
            Debug.Log("Location a new cloud in the sky...");
            float randomX = random.Next(_mapBoundaryX1, _mapBoundaryX2);
            float randomZ = random.Next(_mapBoundaryZ1, _mapBoundaryZ2);
            // float xDeviation;
            // float zDeviation;
            
            Vector3 randomSpawnPosition = new Vector3(randomX, _height, randomZ);
            // Vector3 position = cloud.transform.position;
            // Vector3 closestPoint;
            //
            // CapsuleCollider neighbourCollider;
            //
            //     foreach (GameObject otherCloud in ObjectPool.Instance.pool)
            //     {
            //         if (otherCloud.activeInHierarchy && otherCloud != cloud)
            //         {
            //             neighbourCollider = otherCloud.GetComponentInChildren<CapsuleCollider>();
            //             closestPoint = neighbourCollider.ClosestPoint(position);
            //
            //             xDeviation = closestPoint.x - position.x;
            //             zDeviation = closestPoint.z - position.z;
            //             
            //             if (xDeviation < -_distanceBetweenClouds || xDeviation > _distanceBetweenClouds)
            //             {
            //                 if (zDeviation < -_distanceBetweenClouds || zDeviation > _distanceBetweenClouds)
            //                     cloud.transform.position = randomSpawnPosition;
            //             }
            //         }
            //     }

            cloud.transform.position = randomSpawnPosition;
            cloud.SetActive(true);
            
            Debug.Log("Cloud active!");
        }
    }
}
