using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth = 100;

    bool deadReported;

    public HealthBarScript healthBarScript; // Only for use by player. Ties health to health bar.

    Animator animator;
    public AnimationClip deathClip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        deadReported = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarScript != null)
        {
            healthBarScript.maxHealth = maxHealth;
            healthBarScript.currentHealth = currentHealth;
        }

        if (currentHealth <= 0)
        {
            BecomeDead();
        }
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
    }

    public void BecomeDead()
    {
        if (gameObject.tag == "Enemy")
        {
            if (!deadReported)
            {
                ReportDeath();
            }
        }
        deadReported = true;
        if (animator && deathClip)
        {
            if (!Tools.AnimatorIsPlaying(animator, deathClip.name))
            {
                animator.Play(deathClip.name);
            }
            Destroy(gameObject, deathClip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReportDeath()
    {
        GameObject[] directors = GameObject.FindGameObjectsWithTag("SpawnDirector");
        foreach (GameObject director in directors)
        {
            director.GetComponent<SpawnDirectorScript>().ReportDeath();
        }
    }
    
    // Modifies current health by `value` amount
    public void ChangeHealth(int value)
    {
        if (currentHealth + value < 0)
        {
            currentHealth = 0;
        } 
        else if (currentHealth + value > maxHealth)
        {
            currentHealth = maxHealth;
        } 
        else
        {
            currentHealth += value;
        }
    }
}
