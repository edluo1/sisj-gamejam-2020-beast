using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BasicEnemyState 
{
	Search,
	Charge,
	Attack
}

public class BasicEnemyBehavior : MonoBehaviour
{
	public GameObject target; // who to target
    public GameObject projectile; // what to use to attack
    public float moveSpeed = 1.4f;
	public float inRange; // when player is in range
	public float chargeTime;
	float chargeTimeRemaining;
	SpriteRenderer spriteRenderer;

	BasicEnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BasicEnemyState.Search;
        spriteRenderer = GetComponent<SpriteRenderer>();
        chargeTimeRemaining = chargeTime;
        if (target == null)
        {
            target = GameObject.FindGameObjectsWithTag("Player")[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
    	if (state == BasicEnemyState.Search) {
	        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

	        // Debug.Log(Vector3.Distance(targetPosition, transform.position));
	        if (Vector3.Distance(targetPosition, transform.position) <= inRange) {
	        	state = BasicEnemyState.Charge;
	        }
    	}
    	else if (state == BasicEnemyState.Charge) {
    		float chargeRatio = (chargeTimeRemaining / chargeTime);
            // Debug.Log(chargeRatio);
    		spriteRenderer.color = new Color(1, chargeRatio, chargeRatio); // charge up attack by turning red
    		chargeTimeRemaining -= Time.deltaTime;
    		if (chargeTimeRemaining <= 0) {
    			state = BasicEnemyState.Attack;
    		}
    	}
    	else if (state == BasicEnemyState.Attack) {
    		chargeTimeRemaining = chargeTime;

            // Attack the player.
            Instantiate(projectile, transform.position, transform.rotation);

    		spriteRenderer.color = new Color(1, 1, 1);
    		state = BasicEnemyState.Search;
    	}

    }
}
