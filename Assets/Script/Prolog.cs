using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prolog : MonoBehaviour
{
    private bool clicked = false;
    private byte alpha = 255;
    
    public RawImage black;
    [TextArea] public string word;
    public Text text;

    void Start()
    {
        Screen.SetResolution(800, 600, true);
        black.enabled = true;
        text.enabled = true;
        text.text = word;

        black.color = new Color32(0, 0, 0, alpha);
        text.color = new Color32(255, 255, 255, alpha);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { clicked = true; }
        
        if (clicked)
        {
            alpha -= 15;
            black.color = new Color32(0, 0, 0, alpha);
            text.color = new Color32(255, 255, 255, alpha);
            
            if (alpha == 0)
            {
                black.enabled = false;
                text.enabled = false;
                clicked = false;
                enabled = false;
            }
        }
    }
}