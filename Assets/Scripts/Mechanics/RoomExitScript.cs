using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomExitScript : MonoBehaviour
{
	public bool Enterable = false;
	public string sceneName;

	TilemapCollider2D collider;
    Animator animator;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        collider = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enterable) {
        	collider.isTrigger = true;
        }
    }

    public void OpenRoomExit() {
    	Enterable = true;
    	animator.SetBool("Enterable", true);
    }

    public void OnTriggerEnter() {
    	if (sceneName) {
    		SceneManager.LoadScene(sceneName);
    	}
    	else {
    		Debug.Log("No scene to load!");
    	}
    }
}
