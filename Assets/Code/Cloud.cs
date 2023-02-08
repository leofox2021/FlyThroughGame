using Database;
using UnityEngine;

// ReSharper disable All

public class Cloud : MonoBehaviour
{
    [SerializeField] private GameObject cloud;
    [SerializeField] private float _movementSpeed;

    
    public void FixedUpdate()
    {
        Vector3 currentPosition = cloud.transform.position;
        Vector3 forwardDirection = new Vector3(0, 0, -1);
        
        if (currentPosition.z < Constants.MapBoundaryZ1)
            cloud.SetActive(false);
        else 
            cloud.transform.Translate(forwardDirection * Time.deltaTime * _movementSpeed);
    }
}