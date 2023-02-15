using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

// ReSharper disable All

public class WaypointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _cooldownMsec;

    private Vector3 offset;
    private bool _cooldown = false;
    
    
    public bool Cooldown
    {
        get
        {
            return _cooldown;
        }
    }

    
    public async void GenerateWaypoint()
    {
        Vector3 position = _player.transform.position;
        GameObject newObject = Instantiate(_prefab);

        await Task.Run(() =>
        {
            _cooldown = true;
            Thread.Sleep(_cooldownMsec);
            _cooldown = false;
        });
    }
}
