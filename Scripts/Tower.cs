using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public Slider healthBar;
    public float enemyHealth = 150;
    public bool towerFall;
    public GameObject videoPlayerCanvas2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <=0)
        {
            towerFall = true;
        }   
         healthBar.value = enemyHealth;

         if(towerFall == true)
        {
            videoPlayerCanvas2.SetActive(true);
        }
    }

    private void OnCollisionStay(Collision other) 
    {
        if(other.gameObject.CompareTag("Kilic"))
        {
            enemyHealth = enemyHealth - 10;
        }      
    }
}
