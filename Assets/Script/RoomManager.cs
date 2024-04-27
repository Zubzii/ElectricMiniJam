using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject cameras;

    public GameObject cinCam;
        private CinemachineConfiner confiner;
    public PolygonCollider2D scene1Confiner;
    public PolygonCollider2D scene2Confiner;
    public PolygonCollider2D scene3Confiner;

    public GameObject room1Exit;
    public GameObject room2Enterance;
    public GameObject room2Exit;
    public GameObject room3Enterance;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        confiner = cinCam.GetComponent<CinemachineConfiner>();
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Room1Exit")
        {
            this.transform.position = room2Enterance.transform.position;
            cameras.transform.position = room2Enterance.transform.position;
            confiner.m_BoundingShape2D = scene2Confiner;
        }
        if (collision.gameObject.name == "Room2Exit")
        {
            this.transform.position = room3Enterance.transform.position;
            cameras.transform.position = room3Enterance.transform.position;
            confiner.m_BoundingShape2D = scene3Confiner;
        }
        if (collision.gameObject.name == "Room2Enterance")
        {
            this.transform.position = room1Exit.transform.position;
            cameras.transform.position = room1Exit.transform.position;
            confiner.m_BoundingShape2D = scene1Confiner;
        }
        if (collision.gameObject.name == "Room3Enterance")
        {
            this.transform.position = room2Exit.transform.position;
            cameras.transform.position = room2Exit.transform.position;
            confiner.m_BoundingShape2D = scene2Confiner;
        }
    }

}
