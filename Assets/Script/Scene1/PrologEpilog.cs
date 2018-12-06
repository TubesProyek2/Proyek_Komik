using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologEpilog : MonoBehaviour
{
    private bool clicked = false;
    private byte alpha;
    
    public bool initTrans;
    public RawImage blackBackground;
    public string word;
    public Text text;

    void Start()
    {
        text.text = word;

        if (initTrans)
        { this.alpha = 0; this.enabled = false; }
        else
        { this.alpha = 255; }

        text.color = new Color32(255, 255, 255, alpha);
        blackBackground.color = new Color32(0, 0, 0, alpha);
    }

    void Update()
    {
        if (initTrans)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("klik");
                for (int i = alpha; i <= 255; i++)
                {
                    Debug.Log("for");
                    alpha += 5;
                    Color color = new Color32(0, 0, 0, alpha);
                    blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, color.a);
                }
            }

            if (alpha == 255) { Destroy(this); }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                clicked = true;
            }

            if (alpha == 0) { Destroy(this); }
        }

        if (clicked)
        {
            if (initTrans)
            {
                Debug.Log("tes");
            }
            else
            {
                Debug.Log("klik");
                for (int i = alpha; i > 0; i--)
                {
                    Debug.Log("for");
                    Debug.Log(alpha);
                    alpha -= 5;
                    Color color = new Color32(0, 0, 0, alpha);
                    blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, color.a);
                    text.color = new Color(text.color.r, text.color.g, text.color.b, color.a);
                }
            }
            
        }
    }
}
