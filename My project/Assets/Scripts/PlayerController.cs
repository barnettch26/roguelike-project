using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    // Player Stats
    public bool canMove;
    public float speed;
    public float jumpHeight;

    // Animations
    private Animator myAnimator;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        speed = 5;
        jumpHeight = 8;

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for movement
        if (canMove)
        {
            // Check Direction
            float walkX = Input.GetAxis("Horizontal");
            float walkY = Input.GetAxis("Vertical");

            // Moves the character
            Vector3 move = transform.right * walkX + transform.forward * walkY;
            controller.Move(move * Time.deltaTime * 2);

            // Play Walking Animation
            if (walkX != 0 || walkY != 0)
            {
                if (myAnimator != null)
                {
                    myAnimator.Play("LegsLayer", 0, 0.25f);
                }
            }

            // Jump function. No gravity
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f);
            }

            // Play Shooting myAnimator
        }
    }
}
