using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Tooltip("Oyuna kaç can ile başlayacağı / Maksimum canı")]
    [SerializeField] private int maxHealth;
    public int CurrentHealth { get; private set; }
    public bool IsDead { get; private set; }
    
     private void Start()
     {
         CurrentHealth = maxHealth;
     }

     //Can alma
     public void TakeDamage(int damageAmount)
     {
         if (damageAmount >= CurrentHealth && !IsDead)
         {
             Die();
             return;
         }
         CurrentHealth -= damageAmount;
         Debug.Log(gameObject.name + " damaged " + damageAmount + "hp");
     }

     //Can verme
     public void GiveHealth(int healthAmount)
     {
         if (CurrentHealth + healthAmount >= maxHealth)
         {
             CurrentHealth = maxHealth;
             return;
         }

         CurrentHealth += healthAmount;
         Debug.Log(gameObject.name + " healed " + healthAmount + "hp");
     }

     private void Die()
     {
         //Ölünce ne olacağını buraya yazın.
         IsDead = true;
         Debug.Log(gameObject.name + " dead.");
     }
}