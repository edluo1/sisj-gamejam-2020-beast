using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticuleScript : MonoBehaviour
{
    public Sprite inactiveReticule;
    public Sprite activeReticule;
    SpriteRenderer spriteRenderer;
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            spriteRenderer.sprite = activeReticule;
        }
        else
        {
            spriteRenderer.sprite = inactiveReticule;
        }
    }
}
