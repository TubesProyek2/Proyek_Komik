using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    private bool entered = false;
    private byte alpha = 0;

    public Dialog dialog;
    public GameObject mpu, mpuSit;
    public RawImage black, wordsBox;
    public Text speakerBox, dialogBox;

    void Start()
    {
        dialog.enabled = false;
        mpu.SetActive(true);
        mpuSit.SetActive(false);
        black.color = new Color32(0, 0, 0, alpha);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == mpu.name)
        { entered = true; }
    }

    void Update()
    {
        if(entered)
        {
            for (int i = alpha; i < 0; i++)
            {
                alpha += 5;
                Color col = new Color32(0, 0, 0, alpha);
                black.color = new Color(black.color.r, black.color.g, black.color.b, col.a * Time.deltaTime);

                //black.color = new Color32(0, 0, 0, alpha);
            }

            if(alpha==255)
            {
                mpu.SetActive(false);
                mpuSit.SetActive(true);
                dialog.enabled = true;
            }
        }

        if (mpuSit.activeSelf)
        {
            for (int i = alpha; i > 0; i--)
            {
                alpha -= 5;
                Color col = new Color32(0, 0, 0, alpha);
                black.color = new Color(black.color.r, black.color.g, black.color.b, col.a * Time.deltaTime);

                //black.color = new Color32(0, 0, 0, alpha);
            }
        }
    }
}
