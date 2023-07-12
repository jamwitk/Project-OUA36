using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushrooms : MonoBehaviour
{
    [SerializeField] private int valueOfEffect;
    public MushroomType mushroomType;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        var healthOfPlayer = other.transform.parent.GetComponent<Health>();
        switch (mushroomType)
        {
            case MushroomType.Red:
                healthOfPlayer.TakeDamage(valueOfEffect);
                Destroy(gameObject);
                break;
            case MushroomType.Blue:
                healthOfPlayer.GiveHealth(valueOfEffect);
                Destroy(gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }
}

public enum MushroomType
{
    Red,
    Blue,
}
