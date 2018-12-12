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
    public GameObject mainCamera, mpu, mpuPose;
    public RawImage black;
    public Vector3 cameraPostition, cameraRotation;

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>(); em = ps.emission; em.enabled = true;
        dialogScript.enabled = false;
        cameraControlScript = mainCamera.GetComponent<CameraControl>(); cameraControlScript.enabled = true;
        mpu.SetActive(true); mpuPose.SetActive(false);
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
                mpuPose.SetActive(true);
                mainCamera.transform.position = cameraPostition;
                mainCamera.transform.rotation = Quaternion.Euler(cameraRotation);
                entered = false;
            }
        }

        if (mpuPose.activeSelf)
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