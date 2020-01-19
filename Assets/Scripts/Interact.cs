using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    // THIS IS ATTACHED TO THE CONTROLLERS
    // CHECKS IF COLLIDING WITH OBJECTS WITH
    // COLLIDERS //AND RIGIDBODIES

    public bool orbCollide = false;

    GameObject orbGO; 

    void Update() {
       // if (orbGO != null && orbCollide) {
       //     orbGO.GetComponent<TriggerInteract>().OrbAnimFlow();
       //    // orbGO.GetComponent<TriggerInteract>().OrbAnimFlow();

       //    print("start coroutine");
       //} else if (!orbCollide){
       //     print("stopping coroutine");
       //}
    }

    // it is initially going until player presses and gets in and out

    void OnTriggerEnter(Collider other) {
        print("interacting with " + other.name);
        //if (other.name == "ORB") {
        //    orbGO = other.gameObject;
        //    orbCollide = true;
        //    orbGO.GetComponent<TriggerInteract>().animationStart();
        //}
    }


    void OnTriggerExit(Collider other) {
        //print(" STOPPED interacting with " + other.name);
        //if (other.name == "ORB")
        //{
        //    orbCollide = false;
        //    // we trigger script on ORB
        //    orbGO.GetComponent<TriggerInteract>().animationPause();


        //}
    }
}
