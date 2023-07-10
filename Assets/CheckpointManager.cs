using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; }
    public List<Checkpoint> Checkpoints { get; private set; }
    private void Awake()
    {
        Instance = this;
        Checkpoints = new List<Checkpoint>();
    }
    public void AddCheckpoint(Checkpoint checkpoint)
    {
        Checkpoints.Add(checkpoint);
    }
    public void RemoveCheckpoint(Checkpoint checkpoint)
    {
        Checkpoints.Remove(checkpoint);
    }
    public Vector3 GetLastCheckpoint()
    {
        return Checkpoints[^1].GetSpawnPoint();
    }
}
