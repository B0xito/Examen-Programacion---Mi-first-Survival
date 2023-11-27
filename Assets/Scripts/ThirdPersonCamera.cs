using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] Transform player;

    [Range(10f, 100f)]
    [SerializeField] float mouseSensitivity;
    [SerializeField] float verticalRotation = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= inputY;

        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * verticalRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
