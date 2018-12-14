using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 360.0f;
    private float currentY = 0.0f;


    public float currentX = -90.0f;
    public float distance = 10.0f;
    public float sensitivityX = 5.0f;
    public float sensitivityY = 5.0f;
    public Transform lookAt;
    public Transform camTransform;

    private void Start()
    { camTransform = transform; }

    private void Update()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window
        Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
        Cursor.lockState = CursorLockMode.None;     // set to default default

        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(-currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
