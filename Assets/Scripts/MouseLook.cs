using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform player;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//making the cursor invisible
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;//getting the mouse input
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;//getting the mouse input
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);//clamping the rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);//rotating the player on the x axis
    }
}
