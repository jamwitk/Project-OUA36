using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimatedRock : MonoBehaviour
{
    private Vector3 _startingPos;
    private Vector3 _goingTo;
    public float speed = 1f;
    public float distance = 2f;
    private void Start()
    {
        _startingPos = transform.position + Vector3.left * distance;
        _goingTo = transform.position - Vector3.left * distance;
    }

    private void Update()
    {
        //move from -3 to 3 and back to -3
        transform.position = Vector3.Lerp(_startingPos, _goingTo, Mathf.PingPong(Time.time * speed, 1));
    }
}
