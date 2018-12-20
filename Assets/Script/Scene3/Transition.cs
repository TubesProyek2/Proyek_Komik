using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    private bool entered = false;
    private byte alpha = 0;
    private CameraControl cameraControlScript;
    private int scenes = 0, currentlyDisplayingText = 0, currentlyDisplayingSpeaker = 0;
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule em, fg;

    public GameObject mainCamera, mainCamera2, mpu, mpuBuild, mpuWash, templeFull, templeHalf;
    public ParticleSystem fog;
    public RawImage black, dialogBox;
    [TextArea] public string[] speaker, words;
    public Text speakerBox, wordsBox;
    public TheEnd endScript;
    public Vector3 cam1Postition, cam1Rotation, cam2Postition, cam2Rotation;

    void Awake()
    {
        ps = gameObject.GetComponent<ParticleSystem>(); em = ps.emission; em.enabled = true;
        fg = fog.emission; fg.enabled = false;

        cameraControlScript = mainCamera.GetComponent<CameraControl>(); cameraControlScript.enabled = true;
        mainCamera2.SetActive(false);
        
        mpu.SetActive(true);
        mpuBuild.SetActive(false); mpuWash.SetActive(false);
        templeHalf.SetActive(false); templeFull.SetActive(false);

        dialogBox.enabled = false; speakerBox.enabled = false; wordsBox.enabled = false;

        endScript.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == mpu.name)
        {
            entered = true;

            black.enabled = true;
            black.color = new Color32(0, 0, 0, alpha);

            scenes = 1;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { entered = true; }

        if (black.color.a == 0 && Input.GetMouseButtonDown(0))
        { SkipToNextText(); }

        if (scenes == 1 && entered)
        { Fade2Black(mpu, mpuBuild, templeFull, templeHalf, 2, cam1Postition, cam1Rotation); }

        if (scenes == 2 && entered)
        { Fade2Black(mpuBuild, mpuWash, templeHalf, templeFull, 3, cam1Postition, cam1Rotation); }

        if (scenes == 3 && entered)
        {
            mainCamera2.SetActive(true); mainCamera.SetActive(false);
            Fade2Black(mpu, mpuWash, templeHalf, templeFull, 4, cam2Postition, cam2Rotation);
            fg.enabled = true;
        }

        if (scenes == 4 && entered)
        {
            endScript.enabled = true;
            Destroy(gameObject);
        }
    }

    void Fade2Black(GameObject mpu1, GameObject mpu2, GameObject temple1, GameObject temple2, int s, Vector3 campos, Vector3 camrot)
    {
        if (!mpu2.activeSelf)
        {
            alpha += 15;
            black.color = new Color32(0, 0, 0, alpha);

            if (alpha == 255)
            {
                em.enabled = false;

                cameraControlScript.enabled = false;
                mainCamera.transform.position = campos;
                mainCamera.transform.rotation = Quaternion.Euler(camrot);

                mpu1.SetActive(false); mpu2.SetActive(true);
                temple1.SetActive(false); temple2.SetActive(true);

                dialogBox.enabled = true; speakerBox.enabled = true; wordsBox.enabled = true;
            }
        }

        if (mpu2.activeSelf)
        {
            alpha -= 15; if (alpha == 1) { alpha = 0; }
            black.color = new Color32(0, 0, 0, alpha);

            if (alpha == 0)
            { scenes = s; StartCoroutine(AnimateText()); entered = false;}
        }
    }

    void SkipToNextText()
    {
        StopAllCoroutines();

        currentlyDisplayingSpeaker++;
        if (currentlyDisplayingSpeaker > speaker.Length - 1)
        { currentlyDisplayingSpeaker = 0; }

        currentlyDisplayingText++;
        if (currentlyDisplayingText > words.Length - 1)
        { StopAllCoroutines(); }
        else
        { StartCoroutine(AnimateText()); }
    }

    IEnumerator AnimateText()
    {
        for (int j = 0; j < (speaker[currentlyDisplayingSpeaker].Length); j++)
        { speakerBox.text = speaker[currentlyDisplayingSpeaker]; }

        for (int i = 0; i < (words[currentlyDisplayingText].Length); i++)
        {
            wordsBox.text = words[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.01f);
        }
    }
}
