using UnityEngine;

// ReSharper disable All

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        Vector3 cameraPosition = _target.position;
        Vector3 cameraRotation = _target.eulerAngles;
        
        transform.position = cameraPosition;
        transform.eulerAngles = cameraRotation;
    }
}
