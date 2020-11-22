using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class RoomExitScript : MonoBehaviour
{
	public bool Enterable = false;
	public string sceneName;

	TilemapCollider2D collider;
    Animator animator;

    SpawnDirectorScript spawnDirector;
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        collider = GetComponent<TilemapCollider2D>();
        spawnDirector = GameObject.FindGameObjectWithTag("SpawnDirector").GetComponent<SpawnDirectorScript>();
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

    void OnTriggerEnter2D(Collider2D other) {
    	if (!string.IsNullOrEmpty(sceneName)) {
    		SceneManager.LoadScene(sceneName);
            spawnDirector.mainBattleTheme.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    	else {
    		Debug.Log("No scene to load!");
    	}
    }
}
