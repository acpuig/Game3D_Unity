using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed; // true -> Player is jummping
    private bool axeKeyWasPressed; // true -> Hit with Axe

    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private Vector3 localScale; 

    [HideInInspector] public bool isFacingRight;

    public float rotateSpeed;
    public Animator anim;
    Vector3 m_EulerAngleVelocity;


    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame -> put key moves in here
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // mov X

        //Make the character jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        //Make the character hit with axe
        if (Input.GetKeyDown(KeyCode.L))
        {
            axeKeyWasPressed = true;
        }

        anim.SetBool("IsGrounded", !jumpKeyWasPressed);
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        anim.SetBool("AxeHit", axeKeyWasPressed);


        //Flip the character
        if (horizontalInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0f, 0f));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.1f);
        }
    }

    // FixedUpdate is called once every fisics updates -> put fisics here
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput * 5 , rigidbodyComponent.velocity.y, 0); //to move the character in x

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return; 
        }

        if (jumpKeyWasPressed)
        {
            int jumpPower = 5;
            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

    }




}
