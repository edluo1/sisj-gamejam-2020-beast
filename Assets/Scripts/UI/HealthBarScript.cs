using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public int maxHealth = 100;

    public int currentHealth = 100;
    int previousHealth; // indicates damage taken

    public int damageIndicatorDrain = 1;

    public Image currentHealthImage, previousHealthImage;

    // Start is called before the first frame update
    void Start()
    {
        previousHealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (previousHealth < currentHealth) // healing from damage
        {
            previousHealth = ( previousHealth + damageIndicatorDrain > currentHealth ? 
                currentHealth : previousHealth + damageIndicatorDrain );
        }
        else if (previousHealth > currentHealth) // taken damage
        {
            previousHealth -= (previousHealth - damageIndicatorDrain < currentHealth ?
                currentHealth : previousHealth - damageIndicatorDrain);
        }

        SetHealthBarValues();
    }

    void SetHealthBarValues()
    {
        // Fill amount is a float between 0 and 1
        float currentHealthFill = (float)currentHealth / (float)maxHealth;
        float previousHealthFill = (float)previousHealth / (float)maxHealth;

        // Set health fills
        currentHealthImage.fillAmount = currentHealthFill;
        previousHealthImage.fillAmount = previousHealthFill;
    }
}
