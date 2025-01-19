using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float CurrentHealth;
    private float MaxHealth = 300f;
    ThirdPersonController playerScript;



    void Start()
    {
        healthBar = GetComponent<Image>();
        playerScript = GameObject.Find("Solider").GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = playerScript.health;
        healthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
