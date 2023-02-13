using System;
using static Database.Constants;
using UnityEngine;
using Random = UnityEngine.Random;

// ReSharper disable All

public class GrassSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    
    [SerializeField] private int _minimumRotationY;
    [SerializeField] private int _maximumRotationY;
    
    [SerializeField] private float _grassSizeX;
    [SerializeField] private float _grassSizeZ;
    
    [SerializeField] private float _spawnChancePercentage;
    
    public float SpawnChancePercentage
    {
        get
        {
            return _spawnChancePercentage;
        }
        set
        {
            if (value < 0.01f)
                _spawnChancePercentage = 0.01f;
            else if (value > 1)
                _spawnChancePercentage = 1;
            else
                _spawnChancePercentage = value;
        }
    }
    
    private System.Random _random = new System.Random();
    
    private const float GrassHeight = 0.5f;
    private const float GrassRotationX = -90f;
    private const float GrassRotationZ = -131.213f;
    
    private const float ZeroChance = 0;
    private const float AbsoluteChance = 1;
    private const int ZeroRotationY = 0;
    private const int MaximumRotationY = 0;
    
    
    private void Awake()
    {
        SpawnChancePercentage = _spawnChancePercentage;
        GenerateGrass();
    }
    
    
    private void GenerateGrass()
    {
        for (float z = MapBoundaryZ1; z < MapBoundaryZ2; z += _grassSizeZ)
        {
            for (float x = MapBoundaryX1; x < MapBoundaryX2; x += _grassSizeX)
            {
                float spawnChance = Random.Range(ZeroChance, AbsoluteChance);
                
                if (spawnChance <= _spawnChancePercentage)
                {   
                    float grassRotationY = _random.Next(_minimumRotationY, _maximumRotationY);
                    
                    Vector3 newGrassPosition = new Vector3(x, GrassHeight, z);
                    Vector3 newEulerAngles = new Vector3(GrassRotationX, grassRotationY, GrassRotationZ);
                        
                    GameObject newGrassBlock = Instantiate(_prefab, newGrassPosition, Quaternion.identity);
                    newGrassBlock.transform.eulerAngles = newEulerAngles;
                }
            } 
        }
    }
}
