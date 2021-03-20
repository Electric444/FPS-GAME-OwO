using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    public Image healthBar;

    public float health = 1f;
    
    public void TakeDamage (float amount)
    {
        health -= amount;
        healthBar.fillAmount = health;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
