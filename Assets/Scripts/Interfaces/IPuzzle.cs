using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuzzleState
{
    Done,
    NotDone
}
public interface IPuzzle
{
    public string Name { get; set; }
    public PuzzleState State { get; set; }  
    public bool IsDone();
}
