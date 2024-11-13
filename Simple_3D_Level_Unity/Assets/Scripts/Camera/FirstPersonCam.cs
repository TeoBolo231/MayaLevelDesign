using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private bool enableMouseRotation;

    public float mouseSensitivity = 10f;
    public int posXClamp = 40;
    public int negXClamp = 20;


    private float mouseX;
    private float mouseY;

    private float xRotation = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -negXClamp, posXClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        player.Rotate(Vector3.up * mouseX);
        
    }
}
