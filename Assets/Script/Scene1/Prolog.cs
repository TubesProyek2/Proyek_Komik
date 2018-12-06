using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prolog : MonoBehaviour
{
    private bool clicked = false;
    private byte alpha;
    
    public RawImage blackBackground;
    [TextArea] public string word;
    public Text text;

    void Start()
    {
        text.text = word;
        
        text.color = new Color32(255, 255, 255, alpha);
        blackBackground.color = new Color32(0, 0, 0, alpha);
    }

    void Update()
    {
        if (true)
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
            if (true)
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
                    blackBackground.color = new Color(blackBackground.color.r, blackBackground.color.g, blackBackground.color.b, color.a * Time.deltaTime);
                    text.color = new Color(text.color.r, text.color.g, text.color.b, color.a * Time.deltaTime);
                    //blackBackground.color = new Color32(0, 0, 0, alpha);
                    //text.color = new Color32(255, 255, 255, alpha);
                }
            }
            
        }
    }
}
