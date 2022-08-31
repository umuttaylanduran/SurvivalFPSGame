using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectItems : MonoBehaviour
{
    PlayerHealth playerHealth;
    //Charackter collider oldu�u i�in playerda ayr�etten rigidbody ve collider eklememize gerek yok trigger i�lemini yapmaki�in
 
       private void Start()
        {
            playerHealth = GetComponent<PlayerHealth>();
        }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthItem"))
        {
            playerHealth.AddHealth(10);
            other.gameObject.SetActive(false);
            if (playerHealth.GetHealth() > 100)
            {
                other.gameObject.SetActive(true);

            }
            Debug.Log("10 Can eklendi" + playerHealth.GetHealth());
        }
  
  
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
