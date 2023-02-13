using UnityEngine;

// ReSharper disable All

public class Grass : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Grass")
            Destroy(gameObject);
    }
}
