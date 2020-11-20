using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    private FMOD.Studio.EventInstance footsteps;

    private float timer = 0.0f;
    float footstepSpeed = 0.2f;

    private Vector3 previousPosition;

    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = gameObject.transform.position;
        if (previousPosition != currentPosition)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }
        previousPosition = currentPosition;

        if (isMoving)
        {
            if (timer > footstepSpeed)
            {
                PlayFootstep();
                timer = 0.0f;
            }
            timer += Time.deltaTime;
        }
    }

    private void PlayFootstep()
    {
        // TODO: Marcy add correct footsteps event
        //footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        //footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        //footsteps.start();
        //footsteps.release();
        Debug.Log("footstep played");
    }
}
