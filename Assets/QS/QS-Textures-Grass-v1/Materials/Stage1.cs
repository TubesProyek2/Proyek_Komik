using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1 : MonoBehaviour
{
    public Canvas Text1;
    public Canvas Text2;
    public Canvas Text3;
    public Canvas Text4;
    public Canvas Text5;
    public Button Bubble1;
    public Button Bubble2;
    public Button Bubble3;
    public Button Bubble4;
    public Button Bubble5;
    public Button Bubble6;

    void Start()
    {
        Text1 = Text1.GetComponent<Canvas>();
        Text2 = Text2.GetComponent<Canvas>();
        Text3 = Text3.GetComponent<Canvas>();
        Text4 = Text4.GetComponent<Canvas>();
        Text5 = Text5.GetComponent<Canvas>();
        Bubble1 = Bubble1.GetComponent<Button>();
        Bubble2 = Bubble2.GetComponent<Button>();
        Bubble3 = Bubble3.GetComponent<Button>();
        Bubble4 = Bubble4.GetComponent<Button>();
        Bubble5 = Bubble4.GetComponent<Button>();
        Bubble6 = Bubble4.GetComponent<Button>();
        Text1.enabled = true;
        Text2.enabled = false;
        Text3.enabled = false;
        Text4.enabled = false;
        Text5.enabled = false;
    }
    public void Text1Press()
    {
        Text1.enabled = false;
        Text2.enabled = true;
        Text3.enabled = false;
        Text4.enabled = false;
        Text5.enabled = false;
    }
    public void Text2Press()
    {
        Text1.enabled = false;
        Text2.enabled = false;
        Text3.enabled = true;
        Text4.enabled = false;
        Text5.enabled = false;
    }
    public void Text3Press()
    {
        Text1.enabled = false;
        Text2.enabled = false;
        Text3.enabled = false;
        Text4.enabled = true;
        Text5.enabled = false;
    }

    public void Text4Press()
    {
        Text1.enabled = false;
        Text2.enabled = false;
        Text3.enabled = false;
        Text4.enabled = false;
        Text5.enabled = true;
    }

    public void Text5Press()
    { Application.LoadLevel("Stage1_2"); }

    public void Text6Press()
    { Application.LoadLevel("Prolog"); }
}