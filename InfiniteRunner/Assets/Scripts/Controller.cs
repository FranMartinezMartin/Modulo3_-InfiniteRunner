using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Animator animator;
    CharacterController cc;
    float movementSpeed;
    float turnSmooth = 0.1f;
    float turnVelocity;
    Rigidbody rb;

    bool isJumping = false;
    float jumpForce = 5f;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        movementSpeed = 5f;
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            walking(true);
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            cc.Move(direction.normalized * movementSpeed * Time.deltaTime);
        } else {
            walking(false);
        }

        isJumping = Input.GetButtonDown("Jump");

        if(isJumping)
        {
            rb.AddForce(new Vector3(0,jumpForce,0), ForceMode.Impulse);
        }
    }

    void walking(bool state){
        Debug.Log("walk");
        animator.SetBool("isWalking", state);
    }

    void jumping(bool state){
        Debug.Log("run");
        animator.SetBool("isJumping", state);
        if (state)
        {
            cc.Move(new Vector3(0, jumpForce, 0));
        }
        
    }

    void running(bool state) {
        Debug.Log("jump");
        animator.SetBool("isRunning", state);
    }

}
