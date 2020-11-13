using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState 
{
	Search,
	Charge,
	Attack
}

public class BasicEnemyBehavior : MonoBehaviour
{
	public GameObject player; // who to target
    public GameObject projectile; // what to use to attack
	public float inRange; // when player is in range
	public float chargeTime;
	float chargeTimeRemaining;
	SpriteRenderer spriteRenderer;

	EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.Search;
        spriteRenderer = GetComponent<SpriteRenderer>();
        chargeTimeRemaining = chargeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
    	if (state == EnemyState.Search) {
	        transform.Translate(Vector3.right * Time.deltaTime);

	        // Debug.Log(Vector3.Distance(targetPosition, transform.position));
	        if (Vector3.Distance(targetPosition, transform.position) <= inRange) {
	        	state = EnemyState.Charge;
	        }
    	}
    	else if (state == EnemyState.Charge) {
    		float chargeRatio = (chargeTimeRemaining / chargeTime);
            // Debug.Log(chargeRatio);
    		spriteRenderer.color = new Color(1, chargeRatio, chargeRatio); // charge up attack by turning red
    		chargeTimeRemaining -= Time.deltaTime;
    		if (chargeTimeRemaining <= 0) {
    			state = EnemyState.Attack;
    		}
    	}
    	else if (state == EnemyState.Attack) {
    		chargeTimeRemaining = chargeTime;

            // Attack the player.
            Instantiate(projectile, transform.position, transform.rotation);

    		spriteRenderer.color = new Color(1, 1, 1);
    		state = EnemyState.Search;
    	}

    }
}
