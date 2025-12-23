using UnityEngine;
/// <summary>
/// put on the FirstContollerObject
/// </summary>

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public bool CanMove = true;
    public float moveSpeed = 5f;
    public float gravity = -9.8f;
    public float jumpForce = 5f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 200f;
    public Transform playerCamera;

    float xRotation = 0f;
    float yVelocity = 0f;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // 鎖定滑鼠在畫面中心
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MouseLook();
        Move();
        Jump();
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Camera 上下（Pitch）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Player 左右（Yaw）
        transform.Rotate(Vector3.up * mouseX);
    }

    void Move()
    {
        if (!CanMove) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;

        // 重力
        if (controller.isGrounded && yVelocity < 0)
            yVelocity = -2f; // 貼地用，避免浮起

        yVelocity += gravity * Time.deltaTime;

        Vector3 velocity = move * moveSpeed;
        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (!CanMove) return;

        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            yVelocity = jumpForce;
        }
    }
}
