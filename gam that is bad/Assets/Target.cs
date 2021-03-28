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
        if (this.gameObject.transform.tag == "Enemy")
        {
            if (!this.gameObject.GetComponent<FollowPlayer>().shot)
                this.gameObject.GetComponent<FollowPlayer>().shot = true;
        }
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
