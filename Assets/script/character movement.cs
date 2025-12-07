using UnityEngine;

public class charactermovement : MonoBehaviour
{
  
    public float rotationSpeed = 150f;  // Speed of turning left/right
    public float moveSpeed = 5f;        // Speed of forward/backward movement

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 1. Get player input
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // 2. Rotate the player (left/right)
        transform.Rotate(0f, horizontal * rotationSpeed * Time.deltaTime, 0f);

        // 3. Move forward/backward based on the direction the player is facing
        Vector3 movement = new Vector3(0, 0, vertical * moveSpeed);

        // 4. Convert local movement into world movement
        movement = transform.TransformDirection(movement);

        // 5. Apply movement through CharacterController
        controller.Move(movement * Time.deltaTime);
    }
}


