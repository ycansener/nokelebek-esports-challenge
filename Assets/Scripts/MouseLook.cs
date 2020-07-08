using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float mouseSensitivity;
    [SerializeField] Transform cursorObject;
    [SerializeField] LineRenderer laser;
    [SerializeField] Transform hand;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private Vector3 cursorVel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -180f, 180f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.CompareTag("Canvas"))
            {
                cursorObject.transform.position = Vector3.SmoothDamp(cursorObject.transform.position, hit.point, ref cursorVel, 0.1f);
            }
        }

        laser.SetPosition(0, hand.position);
        laser.SetPosition(1, cursorObject.position);
    }
}
