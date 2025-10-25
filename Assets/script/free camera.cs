using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFreeCamera : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSensitivity = 2f;
    private float rotX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ·Æ¹«±±¨î±ÛÂà
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotX, transform.eulerAngles.y + mouseX, 0);

        // Áä½L±±¨î²¾°Ê
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}

