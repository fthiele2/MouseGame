using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed; 

    private CharacterController characterController;
    private Animator anm;
    private float ySpeed; //gravity beim springen
    private float originalStepOffset; //fixt ruckeln beim springen

    private bool isRunningJump;
    private bool isIdleJump; 

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset; 
    }


    void Update()
    {
        //Laufen
        anm = GetComponent<Animator>();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(moveDir.magnitude) * speed; 
        moveDir.Normalize();

        //Sprung
        ySpeed += Physics.gravity.y * Time.deltaTime;


        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset; 
            ySpeed = -0.5f; 

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0; 
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
}
