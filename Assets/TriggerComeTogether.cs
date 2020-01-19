using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComeTogether : MonoBehaviour
{
    [SerializeField]
    GameObject[] ct = new GameObject[2];
    private void OnTriggerEnter(Collider other)
    {
        print("interacting with " + other.name);
        if (other.tag == "Player")
        {
            // we trigger the come together
            for (int i = 0; i < ct.Length; i++) {
                ct[i].GetComponent<ComeTogether>().together = true;
            }
        }
    }

}
