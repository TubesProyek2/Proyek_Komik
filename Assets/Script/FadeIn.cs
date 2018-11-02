using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public Texture2D fadeTexture;
    public float fadeSpeed = 5.0f;
    public float alpha = 1.0f;

    // Use this for initialization
    void Start()
    { alpha = 1.0f; }
    
    void OnGUI()
    {
        if (alpha > -1)
        {
            alpha -= fadeSpeed * Time.deltaTime / 10;
            if (alpha < 1)
            {
                Color temp = GUI.color;
                temp.a = alpha;
                GUI.color = temp;
                GUI.DrawTexture(new Rect(0, 0,
                Screen.width, Screen.height), fadeTexture);
            }
        }
    }
}