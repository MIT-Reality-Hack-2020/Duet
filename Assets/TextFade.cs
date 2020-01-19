using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public TextMesh textmesh;
    public string text;
    Color initialColor;
    Color lerpColor;
    float LerpValue, timeValue, timeValue2, speedMod = 0.5f;
    float alpha;
    float timer;
    bool done = false;
 //   public GameObject nextText;

    public static bool nextBreath = false;
    public static bool nextWalk = false;
    public static bool nextTouch = false;
    // Start is called before the first frame update
    void Start()
    {
        initialColor = textmesh.color;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log("done: " + done + " timer  " + timer + "  name:" + this.gameObject.name);
        if (LerpValue < 1.0f && !done)
        {
            LerpValue = Mathf.Lerp(0.0f, 1.0f, timeValue);
            timeValue += (Time.deltaTime * speedMod);
            lerpColor = new Color(initialColor.r, initialColor.g, initialColor.b, LerpValue);
            textmesh.color= lerpColor;
            if (LerpValue == 1.0f)
            {
                done = true;
            }
        }
        else if (done && timer > 4f)
        {
            StartCoroutine("Fade");
            //done = true;
            //Debug.Log("Fade out");

            //LerpValue = Mathf.Lerp(0.0f, 1.0f, timeValue);
            //timeValue += (Time.deltaTime * speedMod);
            //lerpColor = new Color(initialColor.r, initialColor.g, initialColor.b, 1-LerpValue);
            //    textmesh.color = lerpColor;
            //this.gameObject.SetActive(false);
            ////nextText.SetActive(true);
            if (textmesh.text == "Breathe")
            {
                nextBreath = true;
            }
            else if (textmesh.text == "Walk")
            {
                nextWalk = true;
            }
            else if (textmesh.text == "Touch")
            {
                nextTouch = true;
            }
        }
    }
    IEnumerator Fade()
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            Color c = textmesh.color;
            c.a = ft;
            textmesh.color = c;
            yield return null;
        }
    }
}
