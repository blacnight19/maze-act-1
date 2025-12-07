using UnityEngine;

public class camera : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate camera vertically (up/down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -75f, 75f);  // prevents snapping backwards
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player horizontally (left/right)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
