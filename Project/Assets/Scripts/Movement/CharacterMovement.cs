using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private float walkSpeed = 12f;

    [SerializeField]
    private float runSpeed = 20f;

    private float currentSpeed;

    [SerializeField]
    private float jumpHeight = 2f;


    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float gravity = -9.8f;

    private Vector3 velocity;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        Move();
        Jump();

        Gravity();
    }

    void GroundCheck(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
    }

    void Gravity(){
        // 중력
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void Move(){
        float x = Input.GetAxis("Horizontal");    
        float z = Input.GetAxis("Vertical");

        if(Input.GetButton("Run")){
            currentSpeed = runSpeed;
        }else{
            currentSpeed = walkSpeed;
        }
        
        // 움직임
        // transform.forward : 현재 캐릭터가 바라보고 있는 방향
        // transform.right : 현재 캐릭터가 바라보고 있는 방향의 오른쪽
        Vector3 direction = transform.right * x + transform.forward * z;
        characterController.Move(direction * currentSpeed * Time.deltaTime);
    }

    void Jump(){
        // 점프
        if(Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
