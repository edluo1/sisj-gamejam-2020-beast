using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string FootstepEventPath = "";

    public FMOD.Studio.EventInstance footsteps;

    private float timer = 0.0f;
    public float footstepIntervalInSeconds = 0.4f;

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
            if (timer > footstepIntervalInSeconds)
            {
                PlayFootstep();
                timer = 0.0f;
            }
            timer += Time.deltaTime;
        }
    }

    private void PlayFootstep()
    {
        footsteps = FMODUnity.RuntimeManager.CreateInstance(FootstepEventPath);
        footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }
}
