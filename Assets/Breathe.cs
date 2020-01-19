using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float scalingTime, scalingSpeed = .4f, targetScale = 1.1f;
    float length = 2f;

    void Update()
    {
        scalingTime = Time.time * scalingSpeed;
        transform.localScale = new Vector3(
            Mathf.PingPong(scalingTime, length) + targetScale,
            Mathf.PingPong(scalingTime, length) + targetScale, 0
            );
    }
}
