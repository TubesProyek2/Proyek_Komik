using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1 : MonoBehaviour
{    
    private bool enter = false, fading = false, prolog = false;
    private byte transNo = 0, transYes = 255;
    private RawImage tb, f;

    public GameObject black, textBox, fade, supo, supoSit;
    public string[] teks;
    
    void Start()
    {
        black.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        enter = true;
        fade.SetActive(true);
        f = fade.GetComponent<RawImage>();
    }

    void Update()
    {

        //Debug.Log(alpha);
        if (enter && transNo < 255)
        {
            transNo += 5;
            Color color = new Color32(0, 0, 0, transNo);
            f.color = new Color(f.color.r, f.color.g, f.color.b, color.a);
        }
        
        if (transNo == 255)
        {
            textBox.SetActive(true);
            tb = textBox.GetComponent<RawImage>();
        }
    }
}