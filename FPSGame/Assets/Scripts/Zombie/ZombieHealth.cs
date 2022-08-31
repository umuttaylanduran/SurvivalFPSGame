using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int startHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    public int GetHealth()
    {
        return currentHealth;
    }
    public void Hit(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <=0)
        {
            currentHealth = 0;
            //TODO: Zombi öldür.
            Debug.Log("Zombi Öldü Adamýmm"+ currentHealth);
        }
        Debug.Log("Zombi hasar aldý" + currentHealth);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
