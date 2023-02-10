using UnityEngine;

// ReSharper disable All

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;


    public void LateUpdate()
    {
        Vector3 cameraPosition = target.position;
        Vector3 cameraRotation = target.eulerAngles;
        
        transform.position = cameraPosition;
        transform.eulerAngles = cameraRotation;
    }
}
