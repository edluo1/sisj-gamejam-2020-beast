﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HurtboxScript : MonoBehaviour
{
    BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("entered");
        if (col.gameObject.tag == "Hitbox") // hit by hitbox
        {
            HitboxScript hitbox = col.gameObject.GetComponent<HitboxScript>();
            if (hitbox.active)
            {
                int damageTaken = col.gameObject.GetComponent<HitboxScript>().damageToGive;
                transform.parent.GetComponent<HealthScript>().TakeDamage(damageTaken);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("entered");
        if (col.gameObject.tag == "Hitbox") // hit by hitbox
        {
            HitboxScript hitbox = col.gameObject.GetComponent<HitboxScript>();
            if (hitbox.active)
            {
                int damageTaken = col.gameObject.GetComponent<HitboxScript>().damageToGive;
                transform.parent.GetComponent<HealthScript>().TakeDamage(damageTaken);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (!box)
            return;

        var offset = box.offset;
        var extents = box.size * 0.5f;
        var verts = new Vector2[] {
            transform.TransformPoint (new Vector2 (-extents.x, -extents.y) + offset),
            transform.TransformPoint (new Vector2 (extents.x, -extents.y) + offset),
            transform.TransformPoint (new Vector2 (extents.x, extents.y) + offset),
            transform.TransformPoint (new Vector2 (-extents.x, extents.y) + offset) };

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(verts[0], verts[1]);
        Gizmos.DrawLine(verts[1], verts[2]);
        Gizmos.DrawLine(verts[2], verts[3]);
        Gizmos.DrawLine(verts[3], verts[0]);
    }
}