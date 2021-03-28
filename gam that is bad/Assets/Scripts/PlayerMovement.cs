using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController CC;

    public float speed;
    public float gravity = -9.81f;

    public float jumpH;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        CC = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        CC.Move(move * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpH * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        CC.Move(velocity * Time.deltaTime);

    }
}
