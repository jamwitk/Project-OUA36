using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Vector3 _spawnpoint;

    void Start()
    {
        _spawnpoint = gameObject.transform.position;
    }

    public Vector3 GetSpawnPoint()
    {
        return _spawnpoint;
    }
    
}