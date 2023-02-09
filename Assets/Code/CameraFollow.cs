using UnityEngine;

// ReSharper disable All

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float _smoothing;


    public void LateUpdate()
    {
        Vector3 cameraPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPosition, _smoothing);
        // Vector3 cameraRotation = new Vector3(0, target.eulerAngles.y, 0);
        
        transform.position = smoothedPosition;
        transform.LookAt(target);
        // transform.eulerAngles = cameraRotation;
    }
}
