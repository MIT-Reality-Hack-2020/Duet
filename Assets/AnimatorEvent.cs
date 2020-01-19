using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AlertObservers(string message)
    {
        if (message.Equals("OrbSpawn"))
        {
            //pc_attacking = false;
            //pc_anim.SetBool("attack", false);
            // spawn orb
            print("SPAWNING THE ORB");
            SpawnPoint.spawnOrb = true;
            //SpawnPoint.spawnTheOrb(returnSphereLocation());
            DestroySpheres();
        } else if(message.Equals("d")) {
            DestroySpheres();
        }
    }

    public Transform returnSphereLocation() {
    print("returning the right transform");
        return transform;
    }

    public void DestroySpheres()
    {
        Destroy(this.gameObject);
    }

}
