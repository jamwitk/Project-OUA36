using System;
using UnityEngine;

namespace Puzzle
{
    public class MagaraPuzzle : MonoBehaviour, IPuzzle
    {
        public static MagaraPuzzle Instance { get; private set; }
        public Animator doorAnimator;
        private void Awake()
        {
            Instance = this;
        }
        public PuzzleState State { get; set; }
        public string Name { get; set; }
        public int rocksCount = 5;
        private int _rockCounter = 0;
        public bool IsDone()
        {
            return State == PuzzleState.Done;
        }

        private void Start()
        {
            PuzzleManagers.Instance.AddPuzzle(this);
            Name = "MagaraPuzzle";  
        }

        private void Done()
        {
            State = PuzzleState.Done;
            print("Magara Puzzle Done");
            doorAnimator.SetTrigger("FirstDoor");
            //TODO: 
            //animation? 
            //sound?
            //particle?
        }
        public void PlaceRockCounter()
        {
            _rockCounter++;
            print("rock counter: " + _rockCounter);
            if (_rockCounter == rocksCount)
            {
                Done();
            }
        }

        public void UnPlaceRockCounter()
        {
            _rockCounter--;
        }
    }
}