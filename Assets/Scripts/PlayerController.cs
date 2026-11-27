using System;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform flashlight1;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float speed = 3;
    private CharacterController controller;
    private float verticalVelocity;

    private float maxLookAngle = 85f;
    public float gravity = -9.81f;
    
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
        flashlight1.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Rotate the player body horizontally
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMoving()
    {
        float inputX = Input.GetAxis("Horizontal");
        float moveX = 0;
        if (inputX < 0)
        {
            moveX = -1;
        }
        else if (inputX > 0)
        {
            moveX = 1;
        }

        float inputZ = Input.GetAxis("Vertical");
        float moveZ = 0;
        if (inputZ < 0)
        {
            moveZ = -1;
        }
        else if (inputZ > 0)
        {
            moveZ = 1;
        }
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -1f;
        }
        
        Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized * speed;
        verticalVelocity += gravity * Time.deltaTime;
        move.y = verticalVelocity;
        controller.Move(move * Time.deltaTime);
        Debug.Log($"X: {moveX}, Z: {moveZ}");
    }
    
}
