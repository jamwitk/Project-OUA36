using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManagers : MonoBehaviour
{
    public static PuzzleManagers Instance { get; private set; }
    public List<IPuzzle> Puzzles { get; private set; }
    private void Awake()
    {
        Instance = this;
        Puzzles = new List<IPuzzle>();
    }
    public void AddPuzzle(IPuzzle puzzle)
    {
        Puzzles.Add(puzzle);
    }
    public void RemovePuzzle(IPuzzle puzzle)
    {
        Puzzles.Remove(puzzle);
    }
    public IPuzzle GetPuzzle(string name)
    {
        return Puzzles.Find(p => p.Name == name);
    }
    
}
