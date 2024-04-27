using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private GameObject player;
    
    public GameObject room1Exit;
    public GameObject room2Enterance;
    public GameObject room2Exit;
    public GameObject room3Enterance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RoomExit1")
        {
            player.transform.position = room2Enterance.transform.position;
        }  
        if (collision.gameObject.name == "RoomExit2")
        {
            player.transform.position = room3Enterance.transform.position;
        }
        if(collision.gameObject.name == "RoomEnterance2")
        {
            player.transform.position = room1Exit.transform.position;
        }
        if (collision.gameObject.name == "RoomEnterance3")
        {
            player.transform.position = room2Exit.transform.position;
        }
    }

}
