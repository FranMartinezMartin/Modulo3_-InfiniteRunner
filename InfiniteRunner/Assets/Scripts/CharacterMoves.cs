using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMoves : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movement;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float speed = 5f;
    float turnSmooth = 1f;
    float turnVelocity;
    Animator animator;
    [SerializeField] bool isGrounded = false;

    [SerializeField] float distToGround = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jumping(true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } else if(!isGrounded)
        
        movement = new Vector3(horizontal,0f,vertical).normalized;
        if(movement.magnitude >= 0.1f)
        {
            walking(true);
            float targetAngle = Mathf.Atan2(movement.x,movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
        } else{
            walking(false);
        }
    }

    private void FixedUpdate() {
        
        Move(movement);

        GroundCheck();
    }

    void Move(Vector3 direction)
    {
        //rb.AddForce(direction.normalized * speed, ForceMode.Acceleration);
        rb.MovePosition(rb.position + direction.normalized * speed * Time.fixedDeltaTime);
    }

    void walking(bool state)
    {
        animator.SetBool("isWalking", state);
    }

    void jumping(bool state)
    {
        animator.SetBool("isJumping", state);        
    }

    void running(bool state) {
        animator.SetBool("isRunning", state);
    }


    void GroundCheck()
    {
        if(Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
        {
            Debug.Log("grounded");
            isGrounded = true;
        } else 
        {
            //Debug.Log("not grounded");
            isGrounded = false;
        }
        Debug.DrawRay(transform.position, Vector3.down);
    }
}
