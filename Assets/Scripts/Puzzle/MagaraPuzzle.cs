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
            //TODO: KAPI ACILACAK
            //animation? 
            //sound?
            //particle?
        }
        public void PlaceRockCounter()
        {
            _rockCounter++;
            print("rock counter: " + _rockCounter);
            if (_rockCounter == 3)
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