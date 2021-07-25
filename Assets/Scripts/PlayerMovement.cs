using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    public float speed = 12f;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundRadius = 0.4f;
    bool isGrounded;

    public float jumpHeight = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();//getting the charecter controller from the player
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);//checking is the player is touching the ground

        if (isGrounded && velocity.y <0) //if the player is touching the ground
        {
            velocity.y = -2f; //set the players gravity to -2f
        }

        float x = Input.GetAxis("Horizontal");//getting the horizontal input
        float z = Input.GetAxis("Vertical");//getting the vertical input

        Vector3 move = transform.right * x + transform.forward * z;//setting the move variable locally
        controller.Move(move * speed * Time.deltaTime);//moving the player


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)//checking if the player is pressing the spacebar and is on the ground
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);//jumping
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);//setting the gravity

        
    }
}
