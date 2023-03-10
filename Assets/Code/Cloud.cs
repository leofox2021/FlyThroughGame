using Database;
using UnityEngine;

// ReSharper disable All

public class Cloud : MonoBehaviour
{
    [SerializeField] private GameObject _cloud;
    [SerializeField] private float _movementSpeed;

    
    private void FixedUpdate()
    {
        Vector3 currentPosition = _cloud.transform.position;
        Vector3 forwardDirection = new Vector3(0, 0, -1);
        
        if (currentPosition.z < Constants.MapBoundaryZ1)
            _cloud.SetActive(false);
        else 
            _cloud.transform.Translate(forwardDirection * Time.deltaTime * _movementSpeed);
    }
}