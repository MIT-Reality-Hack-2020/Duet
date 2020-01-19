using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToStart : MonoBehaviour
{
    public static bool start = false;

    private void OnTriggerExit(Collider other)
    {
        print("interacting with " + other.name);
        if (other.tag == "Controller")
        {
            print("starting");
            start = true;
        }
    }
}
