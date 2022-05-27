using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomDetails : MonoBehaviour
{

    public GameObject currentRoom;
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = GameObject.Find("Room 1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrentRoom(GameObject room)
    {
        currentRoom = room;
    }
}
