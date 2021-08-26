using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    Rigidbody rb;
    public Slider healthBar;
    public float currentHealth;
    public float maxHealth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth / maxHealth; // 밸류값은 1 이라 퍼센트로접근함

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            TakeDamage(10);
        }
        else
            return;
    }

    public void TakeDamage(int a)
       
    {
        currentHealth -= a;
        healthBar.value = currentHealth;
        if (currentHealth <=0)
        {
            Death();

        }
        else if (currentHealth <= 20)
        {
           
        }
        else if (currentHealth <= 60)
        {
            
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
