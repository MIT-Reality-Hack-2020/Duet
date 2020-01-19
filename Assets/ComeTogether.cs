using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeTogether : MonoBehaviour
{
    public bool together = false;
    public GameObject arch1, arch2, arch3, touch;
    bool done = false;

    float timer;

    public Animator ball1, ball2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (together && !done)
        {
            Rigidbody gameObjectsRigidBody1 = arch1.AddComponent<Rigidbody>();
            Rigidbody gameObjectsRigidBody2 = arch2.AddComponent<Rigidbody>();
            Rigidbody gameObjectsRigidBody3 = arch3.AddComponent<Rigidbody>();
            ball1.SetTrigger("ToOrb");
            ball2.SetTrigger("ToOrb");
            touch.SetActive(true);
            done = true;
        }
        else if (together && done)
        {
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                arch1.SetActive(false);
                arch2.SetActive(false);
                arch3.SetActive(false);
            }
        }
    }
}
