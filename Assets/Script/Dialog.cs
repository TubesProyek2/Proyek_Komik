using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    private bool triggered;
    private int currentlyDisplayingText = 0, currentlyDisplayingSpeaker = 0;

    public Epilog epilogScript;
    public RawImage black, dialogBox;
    [TextArea] public string[] speaker, words;
    public Text speakerBox, wordsBox;
    
    void Awake()
    {
        dialogBox.enabled = false;
        speakerBox.enabled = false; wordsBox.enabled = false;
        enabled = false;
    }

    void Start()
    {
        dialogBox.enabled = true;
        speakerBox.enabled = true; wordsBox.enabled = true;
        speakerBox.text = ""; wordsBox.text = "";
        StartCoroutine(AnimateText());
    }

    public void SkipToNextText()
    {
        StopAllCoroutines();
        
        currentlyDisplayingSpeaker++;
        if (currentlyDisplayingSpeaker > speaker.Length-1)
        { currentlyDisplayingSpeaker = 0; }

        currentlyDisplayingText++;
        if (currentlyDisplayingText > words.Length-1)
        {
            StopAllCoroutines();
            epilogScript.enabled = true;
            enabled = false;
        }
        else
        { StartCoroutine(AnimateText()); }
    }

    IEnumerator AnimateText()
    {
        for (int j = 0; j <= (speaker[currentlyDisplayingSpeaker].Length); j++)
        { speakerBox.text = speaker[currentlyDisplayingSpeaker]; }

        for (int i = 0; i <= (words[currentlyDisplayingText].Length); i++)
        {
            wordsBox.text = words[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.01f);
        }
    }

    void Update()
    {
        if (black.color.a==0 && Input.GetMouseButtonDown(0))
        { SkipToNextText(); } 
    }
}