using UnityEngine;

// ReSharper disable All

public class Cloud : MonoBehaviour
{
    [SerializeField] private Rigidbody cloud;
    [SerializeField] private float _movementSpeed;

    
    public void FixedUpdate()
    {
        Vector3 currentPosition = cloud.transform.position;
        Vector3 forwardDirection = cloud.transform.forward;
        
        cloud.MovePosition(currentPosition + forwardDirection * _movementSpeed * Time.deltaTime);
    }
}