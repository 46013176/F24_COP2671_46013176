using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    public float jumpForce;
    public float turnSpeed;
    public bool isOnGround = true;
    public float horizontalInput, verticalInput;
    public Animator characterAnimator;
    private Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            characterAnimator.SetTrigger("JumpTrigger");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isOnGround = false;
        }

        if(verticalInput == 0)
        {
            characterAnimator.SetFloat("Speed", 0);
        }
        else if(verticalInput > 0)
        {
            characterAnimator.SetFloat("Speed", 1);
        }
        else
        {
            characterAnimator.SetFloat("Speed", -1);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
