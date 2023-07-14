using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollider : MonoBehaviour
{
    private GameObject _checkpoint;
    private void Start()
    {
        _checkpoint = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Spawnenemys.spawned = true;
            if(_checkpoint.GetComponent<Checkpoint>().IsTaken()) return;
            CheckpointManager.Instance.AddCheckpoint(_checkpoint.GetComponent<Checkpoint>());
            _checkpoint.GetComponent<Checkpoint>().Taken();
            
        }
    }
}
