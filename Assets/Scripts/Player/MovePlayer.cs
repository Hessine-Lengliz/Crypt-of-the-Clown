using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(CharacterController))]


public class MovePlayer : MonoBehaviour

{

    [Header("Movement")]
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    public float jumpSpeed = 8.0f;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public bool canMove = true;
    public float gravity = 20.0f;

    private float moveSpeed;
    private float strafeSpeed;
    private float threshold = 0.3f;

    [Header("View")]
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    float rotationX = 0;

    [Header("Light")]
    private bool isLightEnabled = false;
    private Light Light;

  


    [SerializeField] private float maxStamina = 100f;
    [Header("sounds")]
    public AudioSource WalkingSound;
    public AudioSource runningSound;
    public AudioSource jumpingSound;




    void Start()
    {
        Light = GetComponentInChildren<Light>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


       
       
    }

    void Update()
    {
        // FlashEnable();
        Move();
       Debug.Log("WalkingSound :"+WalkingSound.isPlaying);
        Debug.Log("runningSound :"+runningSound.isPlaying);
        
       

    }

    // Player movement
    void Move()
    {
       Vector3 forward = transform.TransformDirection(Vector3.forward);
    Vector3 right = transform.TransformDirection(Vector3.right);
    // Press Left Shift to run
    bool isRunning = Input.GetKey(KeyCode.LeftShift);
    float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
    float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
    float movementDirectionY = moveDirection.y;
    moveDirection = (forward * curSpeedX) + (right * curSpeedY);

    // Assign the current speed of movement to moveSpeed and strafeSpeed
    moveSpeed = curSpeedX;
    strafeSpeed = curSpeedY;

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    
        // Play sounds based on movement speed
        if(Input.GetButtonDown("Jump")){
            jumpingSound.Play();
            WalkingSound.Stop();
            runningSound.Stop();


        }
        else if (moveSpeed != 0 || strafeSpeed != 0)
        {
            Debug.Log("playermoving");
            if (Input.GetButton("run"))
            {
                if (!runningSound.isPlaying)
                {
                    runningSound.Play();
                    WalkingSound.Stop();
                    jumpingSound.Stop();
                }


            }
            else if (!WalkingSound.isPlaying)
            {
                WalkingSound.Play();
                runningSound.Stop();
            }



        }
        else
        {
            WalkingSound.Stop();
            runningSound.Stop();
        }

    }


    // Player and Camera rotation
    

   

    // Death of player on collision

}

