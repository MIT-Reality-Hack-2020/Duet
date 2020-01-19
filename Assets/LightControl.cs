using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject nextLight;

    Light[] rowLights;
    MeshRenderer[] rowMeshRenderers;

    public float LerpValue = 0;
    float timeValue = 0;
    float speedMod = 0.5f;
    Color lerpColor;
    Color defaultColor;

    float timeOn;

    public GameObject audioSource;

    

    // Start is called before the first frame update
    void Start()
    {
        rowLights = nextLight.GetComponentsInChildren<Light>();
        rowMeshRenderers = nextLight.GetComponentsInChildren<MeshRenderer>();
        defaultColor = rowMeshRenderers[0].material.color;

        for (int i = 0; i < rowLights.Length; i++)
        {
            rowLights[i].intensity = 0;
        }

        for (int j = 0; j < rowMeshRenderers.Length; j++)
        {
            Color transparentColor = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0);
            rowMeshRenderers[j].material.SetColor("_Color", transparentColor);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (nextLight.activeSelf)
        {
            if (LerpValue < 1.0f)
            {
                LerpValue = Mathf.Lerp(0.0f, 1.0f, timeValue);
                timeValue += (Time.deltaTime * speedMod);

                for (int i = 0; i < rowLights.Length; i++)
                {
                    rowLights[i].intensity = LerpValue;
                }

                for (int j = 0; j < rowMeshRenderers.Length; j++)
                {
                    lerpColor = new Color(defaultColor.r, defaultColor.g, defaultColor.b, LerpValue);
                    rowMeshRenderers[j].material.SetColor("_Color", lerpColor);
                }
            }
            else if (timeOn < 3f)
            {
                timeOn += Time.deltaTime;
            }
            else if (timeOn > 3f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextLight.SetActive(true);
            audioSource.transform.position = new Vector3(nextLight.transform.position.x, nextLight.transform.position.y - 0.3f, nextLight.transform.position.z);
        }
    }
}
