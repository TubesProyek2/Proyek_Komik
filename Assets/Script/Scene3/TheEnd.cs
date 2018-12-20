using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheEnd : MonoBehaviour
{
    private byte alpha = 0;

    public RawImage black;
    public string scene;
    [TextArea] public string word;
    public Text text, fin;

    void Awake()
    { fin.enabled = false; enabled = false; }

	// Use this for initialization
	void Start ()
    {
        black.enabled = true;
        text.enabled = true; fin.enabled = true;
        text.text = word;

        black.color = new Color32(0, 0, 0, alpha);
        text.color = new Color32(255, 255, 255, alpha);
        fin.color = new Color32(0, 223, 29, alpha);
    }
	
	// Update is called once per frame
	void Update ()
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
            fin.color = new Color32(0, 223, 29, alpha);
        }
    }
}
