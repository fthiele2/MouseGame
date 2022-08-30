using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float jumpButtonPeriod;
    private float jumpHorizontalSpeed; 

    private CharacterController characterController;
    private Animator anm;
    private float ySpeed; //gravity beim springen
    private float originalStepOffset; //fixt ruckeln beim springen

    private float? lastGroundedTime;
    private float? jumpButtonPressedTime; 

    private bool isJumping;
    private bool isFalling;
    private bool isGrounded;

    void Start()
    {
        anm = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset; 
    }


    void Update()
    {
        //Laufen
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(moveDir.magnitude) * speed; 
        moveDir.Normalize();

        //Sprung
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time; 
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }


        if (Time.time - lastGroundedTime <= jumpButtonPeriod)
        {
            characterController.stepOffset = originalStepOffset; 
            ySpeed = -0.5f;
            anm.SetBool("IsGrounded", true);
            isGrounded = true; 
            anm.SetBool("IsJumping", false);
            isJumping = false;
            anm.SetBool("IsFalling", false);

            if (Time.time - jumpButtonPressedTime <= jumpButtonPeriod)
            {
                anm.SetBool("IsJumping", true);
                isJumping = true; 
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null; 
            }
        }
        else
        {
            characterController.stepOffset = 0;
            anm.SetBool("IsGrounded", false);

            if((isJumping && ySpeed < 0 || ySpeed < -2))
            {
                anm.SetBool("IsFalling", true);
            }
        }


        Vector3 velocity = moveDir * magnitude;
        velocity.y = ySpeed; 
        characterController.Move(velocity * Time.deltaTime); 

        if(moveDir != Vector3.zero)
        {
            anm.SetBool("IsMoving", true); 
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            anm.SetBool("IsMoving", false); 
        }

    }

    private void OnAnimatorMove()
    {
        if (isGrounded)
        {
            Vector3 velocity = anm.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;

            characterController.Move(velocity);
        }
    }
}
