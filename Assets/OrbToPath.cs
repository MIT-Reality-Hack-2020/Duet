using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbToPath : MonoBehaviour
{
    public Animator ball1, ball2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ball1.SetTrigger("ToPath");
            ball2.SetTrigger("ToPath");
        }
    }
}
