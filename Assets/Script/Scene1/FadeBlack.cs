using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    private bool entered = false;
    private byte alpha = 0;
    private CameraControl cameraControlScript;
    private ParticleSystem ps;
    private ParticleSystem.EmissionModule em;

    public Dialog dialogScript;
    public GameObject mainCamera, mpu, mpuSit;
    public RawImage black;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>(); em = ps.emission; em.enabled = true;
        dialogScript.enabled = false;
        cameraControlScript = mainCamera.GetComponent<CameraControl>(); cameraControlScript.enabled = true;
        mpu.SetActive(true); mpuSit.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == mpu.name)
        {
            entered = true;
            black.enabled = true;
            black.color = new Color32(0, 0, 0, alpha);
        }
    }

    void Update()
    {
        if(entered)
        {
            alpha += 15;
            black.color = new Color32(0, 0, 0, alpha);
            
            if(alpha == 255)
            {
                mpu.SetActive(false);
                em.enabled = false;
                cameraControlScript.enabled = false;
                mpuSit.SetActive(true);
                mainCamera.transform.position = new Vector3(-6, 7.5f, 1);
                mainCamera.transform.rotation = Quaternion.Euler(25, -60, 0);
                entered = false;
            }
        }

        if (mpuSit.activeSelf)
        {
            alpha -= 15;
            black.color = new Color32(0, 0, 0, alpha);

            if (alpha == 0)
            {
                dialogScript.enabled = true;
                Destroy(gameObject);
            }
        }
    }
}