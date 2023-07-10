using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthSlider;
    private Health _playerHealth;

    private void Start()
    {
        _playerHealth = PlayerController.Instance.playerHealth;
    }

    private void Update()
    {
        healthSlider.fillAmount = (float)_playerHealth.CurrentHealth / _playerHealth.GetMaxHealth();
    }
}
