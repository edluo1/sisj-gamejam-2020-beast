using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	List<GameObject> allFocusObjects;
	public float maxCameraSpeed = 1.4f;
    // Start is called before the first frame update
    void Start()
    {
        allFocusObjects = new List<GameObject>(2);

        // Add player(s) and Benji(s)
        allFocusObjects.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        allFocusObjects.AddRange(GameObject.FindGameObjectsWithTag("Beast"));
    }

    // Update cameras slowly
    void LateUpdate()
    {
        var cameraPosition = new Vector3(
	        allFocusObjects.Average(focusObject=>focusObject.transform.position.x),
	        allFocusObjects.Average(focusObject=>focusObject.transform.position.y),
	        -10);
        transform.position = Vector3.MoveTowards(transform.position, cameraPosition, maxCameraSpeed);

        var avgDistance = 5f; // TODO change it
        GetComponent<Camera>().orthographicSize = avgDistance;
    }
}
