using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float forceSize;
    private Vector3 forceDirection;
    private Rigidbody rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        forceDirection = new Vector3(horizontalInput, 0, verticalInput);
        forceDirection.Normalize();
    }

    private void FixedUpdate()
    {
        Vector3 force = forceDirection * forceSize;
        rb.AddForce(force); 
    }

}
