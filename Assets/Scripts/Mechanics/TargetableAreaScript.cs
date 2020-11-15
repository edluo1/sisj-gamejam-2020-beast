using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles clickable enemies.
/// Should show a reticle of some sort over them, and then a target once clicked.
/// The beast should attack them, with buttons handling the types of attacks it should do.
/// </summary>
public class TargetableAreaScript : MonoBehaviour
{
    public bool isTargeted = false;
    public GameObject reticule; // Reticule to get when loading is needed.
    GameObject storedReticule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTargeted)
        {
            GameObject[] beasts = GameObject.FindGameObjectsWithTag("Beast");
            foreach (GameObject beast in beasts)
            {
                beast.GetComponent<BeastBehavior>().SetTarget(transform.gameObject);
            }
        }
    }

    /// <summary>
    /// Place ONLY ONE reticule on an enemy.
    /// </summary>
    void CreateReticule()
    {
        if (storedReticule == null)
        {
            storedReticule = Instantiate(reticule) as GameObject;
            storedReticule.transform.parent = transform;
            storedReticule.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    
    /// <summary>
    /// Should place a reticule over the enemy.
    /// </summary>
    void OnMouseOver()
    {
        CreateReticule();
    }

    /// <summary>
    /// Should remove the reticule if not set.
    /// </summary>
    void OnMouseExit()
    {
        // Debug.Log("Target lost");
        if (!isTargeted)
        {
            Destroy(storedReticule);
        }
    }

    /// <summary>
    /// Should lock the beast on the enemy unless clicked off.
    /// </summary>
    void OnMouseDown()
    {
        isTargeted = true;
        if (storedReticule == null)
        {
            CreateReticule();
        }
        storedReticule.GetComponent<ReticuleScript>().isActive = true;
        Debug.Log("Attack this guy!");
    }
}
