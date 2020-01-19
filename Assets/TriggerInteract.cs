using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteract : MonoBehaviour
{

    Animator animator;
    [SerializeField]
    List<GameObject> go = new List<GameObject>();

    public Material[] materials = new Material[2];

    public GameObject childSphere;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        childSphere = transform.Find("Sphere").gameObject;
        
       // materials[0] = childSphere.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    public void animationStart() {
        print("starting");
        animator.enabled = true;
        // change material
        childSphere.GetComponent<MeshRenderer>().material = materials[1];
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void animationPause() {
        print("stopping");
        animator.enabled = false;
        childSphere.GetComponent<MeshRenderer>().material = materials[0];

    }

    private void OnTriggerEnter(Collider other)
    {
        print("interacting with " + other.name);
        if (other.tag == "Controller") {
            print("Adding Controller");
            if (!go.Contains(other.gameObject)) {
                go.Add(other.gameObject);
            }
        }
        if (go.Count >=2) {
            print("array is full ideally so we trigger anim");
            animationStart();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("interacting with " + other.name);
        if (other.tag == "Controller")
        {
            print("Removing Controller");
            if (go.Contains(other.gameObject)) {
            go.Remove(other.gameObject);
            }
        }
        if (go.Count < 2)
        {
            print("array is full ideally so we trigger anim");
            animationPause();
        }
    }

}
