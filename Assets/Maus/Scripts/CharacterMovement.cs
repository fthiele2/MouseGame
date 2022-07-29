using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Animator anm;

    void Start()
    {

    }


    void Update()
    {
        anm = GetComponent<Animator>();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(horizontalInput, 0, verticalInput);
        moveDir.Normalize();

        gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + (moveDir * speed)* Time.deltaTime); 

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
