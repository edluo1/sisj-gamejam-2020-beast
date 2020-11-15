using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("entered");
        if (col.gameObject.tag == "Hitbox") // hit by hitbox
        {
            int damageTaken = col.gameObject.GetComponent<HitboxScript>().damageToGive;
            transform.parent.GetComponent<HealthScript>().TakeDamage(damageTaken);
            Debug.Log("Ow!");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("entered");
        if (col.gameObject.tag == "Hitbox") // hit by hitbox
        {
            int damageTaken = col.gameObject.GetComponent<HitboxScript>().damageToGive;
            transform.parent.GetComponent<HealthScript>().TakeDamage(damageTaken);
            Debug.Log("Ow!");
        }
    }
}
