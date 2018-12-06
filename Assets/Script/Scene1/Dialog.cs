using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    private bool triggered;
    public GameObject mpu, mpuSit;
    [TextArea] public string[] speakers;
    [TextArea] public string[] words;
    public Text speakerBox, dialogBox;
    private int currentlyDisplayingText = 0;
    
    void Start()
    {
        speakerBox.enabled = false; dialogBox.enabled = false;
        mpu.SetActive(true);
        mpuSit.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == mpu.name)
        {
            speakerBox.enabled = true; dialogBox.enabled = true;
            mpu.SetActive(false);
            mpuSit.SetActive(true);
            StartCoroutine(AnimateText());
        }
    }

    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;
        dialogBox.text = words[currentlyDisplayingText];

        if (currentlyDisplayingText > words.Length)
        { currentlyDisplayingText = 0; }

        if (Input.GetMouseButtonDown(0))
        { StartCoroutine(AnimateText()); }
    }

    IEnumerator AnimateText()
    {
        for (int i = 0; i < (words[currentlyDisplayingText].Length + 1); i++)
        {
            dialogBox.text = words[currentlyDisplayingText].Substring(0, i);

            yield return new WaitForSeconds(.01f);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { SkipToNextText(); }
    }
}