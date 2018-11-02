using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage4_3 : MonoBehaviour
{
    public Canvas Text1;
    public Button Bubble1;
    public Button Bubble2;

    void Start()
    {
        Text1 = Text1.GetComponent<Canvas>();
        Bubble1 = Bubble1.GetComponent<Button>();
        Bubble2 = Bubble2.GetComponent<Button>();
        Text1.enabled = true;
    }

    public void Text1Press()
    { Application.LoadLevel("Stage4_4"); }

    public void Text2Press()
    { Application.LoadLevel("Stage3"); }
}
