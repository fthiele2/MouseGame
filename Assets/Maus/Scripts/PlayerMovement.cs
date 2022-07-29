using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private CharacterController characterController;
    private Animator anm;

    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }


    void Update()
    {
        anm = GetComponent<Animator>();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(moveDir.magnitude) * speed; 
        moveDir.Normalize();

        characterController.SimpleMove(moveDir * magnitude); 

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
