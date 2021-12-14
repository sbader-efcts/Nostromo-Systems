using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitAreaScript : MonoBehaviour
{
    public GameObject self;
    public GameObject drone;

    void Update()
    {
        if (self.GetComponent<Collider2D>().IsTouching(drone.GetComponent<Collider2D>()))
        {
            //close "Main"
            //load "NavigationRoomMPTerminal.SelectedScene"
            drone.GetComponent<DroneStuff.DroneMovement>().DoNotAllowMovement = true;
        }
    }
}
