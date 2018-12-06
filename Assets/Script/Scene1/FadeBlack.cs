using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    public bool fadeTo;
    public GameObject mpu;
    public RawImage black;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == mpu.name)
        {
            textBox.enabled = true;
            speakerBox.enabled = true;
            dialogBox.enabled = true;
            mpu.SetActive(false);
            mpuSit.SetActive(true);
            StartCoroutine(AnimateText());
        }
    }
}
