using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HitboxScript : MonoBehaviour
{
    public bool active = true;
    public bool destroyOnHit = false;
    public int damageToGive = 10;

    BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        box.enabled = active;
    }

    public void DestroyOnHit() // Destroys game object on hit (for projectiles)
    {
        Destroy(transform.parent.gameObject);
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

        Gizmos.color = Color.red;
        Gizmos.DrawLine(verts[0], verts[1]);
        Gizmos.DrawLine(verts[1], verts[2]);
        Gizmos.DrawLine(verts[2], verts[3]);
        Gizmos.DrawLine(verts[3], verts[0]);
    }
}
