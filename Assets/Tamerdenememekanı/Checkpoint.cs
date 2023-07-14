using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 _spawnPoint;
    private bool _isTaken = false;
    void Start()
    {
        var tempSpawnPoint = gameObject.transform.position;
        _spawnPoint = tempSpawnPoint + Vector3.up;
    }

    public bool IsTaken()
    {
        return _isTaken;
    }
    public void Taken()
    {
        _isTaken = true;
    }
    public Vector3 GetSpawnPoint()
    {
        return _spawnPoint;
        
}
    
}