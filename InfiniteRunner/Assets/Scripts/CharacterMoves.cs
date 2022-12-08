using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMoves : MonoBehaviour
{
    Rigidbody rb;
    Vector3 movementDir;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] float turnVelocity = 720f;
    Animator animator;
    [SerializeField] bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementDir = new Vector3(horizontal,0f,vertical).normalized;
        
        if(movementDir.magnitude >= 0.1f)
        {
            walking(true);
            transform.Translate(movementDir*speed*Time.deltaTime, Space.World);
            Quaternion toRotation = Quaternion.LookRotation(movementDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnVelocity*Time.deltaTime);
        } else{
            walking(false);
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumping();
        }
        
        /*
        if(movement.magnitude >= 0.1f)
        {
            walking(true);
            float targetAngle = Mathf.Atan2(movement.x,movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref turnVelocity, turnSmooth);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
        } else{
            walking(false);
        }
        */
    }

    private void FixedUpdate() {
        GroundCheck();
    }

    void walking(bool state)
    {
        animator.SetBool("isWalking", state);
    }

    void jumping()
    {
        animator.SetBool("isJumping", true);
        StartCoroutine(landJump());
        animator.SetBool("isJumping", false);
    }

    private IEnumerator landJump(){
        yield return new WaitForSeconds(1.50f);
    }

    void running(bool state) {
        animator.SetBool("isRunning", state);
    }

    void GroundCheck()
    {
        Ray ray = new Ray(transform.position, new Vector3(0,-1,0));
        if(Physics.Raycast(ray, 0.2f)){
            isGrounded = true;
        } else {
            isGrounded = false;
            jumping();
        };
    }
}
