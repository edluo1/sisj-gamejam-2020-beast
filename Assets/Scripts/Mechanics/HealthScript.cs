using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth = 100;

    public HealthBarScript healthBarScript; // Only for use by player. Ties health to health bar.

    Animator animator;
    public AnimationClip deathClip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            // TODO add code to play death animation
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
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
    }
}
