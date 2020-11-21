using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Friendship : MonoBehaviour
{

    public int friendshipValue = 0;

    public int badFriendshipThreshold = -100;
    public int goodFriendshipThreshold = 100;

    private Text friendshipDebugText;
    // Start is called before the first frame update
    void Start()
    {
        friendshipDebugText = GameObject.FindGameObjectWithTag("FriendshipText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeFriendship(int value)
    {
        friendshipValue += value;
        friendshipDebugText.text = "Friendship: " + friendshipValue;
    }
}
