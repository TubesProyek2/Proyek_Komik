using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Epilog : MonoBehaviour
{
    private byte alpha = 0;
    
    public RawImage black;
    public string scene;
    [TextArea] public string word;
    public Text text;

    void Awake()
    { enabled = false; }

    void Start()
    {
        black.enabled = true;
        text.enabled = true;
        text.text = word;

        black.color = new Color32(0, 0, 0, alpha);
        text.color = new Color32(255, 255, 255, alpha);
    }

    void Update()
    {
        if (alpha == 255)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(scene);
                enabled = false;
            }
        }
        else
        {
            alpha += 15;
            black.color = new Color32(0, 0, 0, alpha);
            text.color = new Color32(255, 255, 255, alpha);
        }
        
    }
}