using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform flashlight;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float speed = 3;
    private float maxLookAngle = 85f;
    private CharacterController controller;
    private float verticalRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        HandleLooking();
        HandleMoving();
    }

    private void HandleLooking()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the camera vertically and clamp it so you can't flip upside down
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        flashlight.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Rotate the player body horizontally
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMoving()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move.normalized * speed * Time.deltaTime);
    }
}
