using UnityEngine;
using System.Collections;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movement : MonoBehaviour {
    CharacterController characterController;
    Rigidbody rigidbody;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        gravity = gravity * rigidbody.mass;
    }

    void Update() {
        gravity = gravity * rigidbody.mass;
        if (characterController.isGrounded == true) {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;
            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
            }

       } else if(characterController.isGrounded == false) {
            // Air Control
            /*moveDirection = new Vector3(Input.GetAxis("Horizontal"), -gravity * Time.deltaTime, 0.0f);
            moveDirection *= speed;*/
            /*if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
            }*/
        }



        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        
        moveDirection.y -= gravity * Time.deltaTime;
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}

