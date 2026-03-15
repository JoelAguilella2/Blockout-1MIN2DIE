using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("Jump Parameters")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravityMultiplier = 1.0f;

    [Header("Look Parameters")]
    [SerializeField] private float mouseSensitivity = 0.1f;
    [SerializeField] private float upDownLookRange = 80f;

    [Header ("References")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerInputHandler playerInputHandler;

    public GameObject ascensor;
    public GameObject ascensorBaja;
    
    public AscensorScript ascensorScript;

    public GameObject grabKey;
    public GameObject grabHammer;
    public GameObject personalKey;
    public GameObject personalHammer;
    public GameObject darkness;
    public GameObject toolLight;
    public GameObject windowCollision;
    public GameObject rageEnemy;

    public float secondsToDie;
    public TextMeshProUGUI textSecondsToDie;
    public GameObject textos;

    private Vector3 currentMovement;
    private float verticalRotation;
    private float CurrentSpeed => walkSpeed * (playerInputHandler.SprintTriggered ? sprintMultiplier : 1);
    public bool isTextTriggered;
    public float delayTextStart;
    public const float delayTextCooldown = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        secondsToDie = 60f;
        isTextTriggered = false;
        delayTextStart = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleRotation();

        if(playerInputHandler.ActionTriggered)
        {
            this.transform.position = new Vector3(-14,1,0.7f);
            ascensor.transform.position = new Vector3(-6.41f,-2.52f,22.13f);
            ascensorScript.aSubir = false;
            ascensorScript.aBajar = false;
            ascensorBaja.SetActive(false);
            grabKey.SetActive(true);
            grabHammer.SetActive(true);
            personalKey.SetActive(false);
            personalHammer.SetActive(false);
            darkness.SetActive(true);
            windowCollision.SetActive(true);
            toolLight.SetActive(false);
            rageEnemy.SetActive(false);

            secondsToDie = 60f;

        }

        if(playerInputHandler.DebugTextTriggered)
        {
            if(delayTextStart < delayTextCooldown)
            {
                delayTextStart += Time.deltaTime;
            }
            else
            {

            delayTextStart = 0f; 
            
            
            if(!isTextTriggered)
            {
                textos.SetActive(true);
                isTextTriggered = true;
            }
            else
            {
            textos.SetActive(false);
            isTextTriggered = false;
            }            

            }
        }

        

        //textos.SetActive(!playerInputHandler.DebugTextTriggered);

        if(secondsToDie > 0)
        {
            secondsToDie -= Time.deltaTime;
            textSecondsToDie.text = secondsToDie.ToString("0");

        }
        else
        {
            secondsToDie = 0f;
            textSecondsToDie.text = "0";
        }
    }

    private Vector3 CalculateWorldDirection()
    {
        Vector3 inputDirection = new Vector3(playerInputHandler.MovementInput.x, 0f, playerInputHandler.MovementInput.y);
        Vector3 worldDirection = transform.TransformDirection(inputDirection);
        return worldDirection.normalized;
    }

    private void HandleJumping()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = -0.5f;

            if (playerInputHandler.JumpTriggered)
            {
                currentMovement.y = jumpForce;
            }
        }
        else
        {
            currentMovement.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    private void HandleMovement()
    {
        Vector3 worldDirection = CalculateWorldDirection();
        currentMovement.x = worldDirection.x * CurrentSpeed;
        currentMovement.z = worldDirection.z * CurrentSpeed;

        HandleJumping();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    private void ApplyHorizontalRotation(float rotationAmount)
    {
        transform.Rotate(0, rotationAmount, 0);
    }

    private void ApplyVerticalRotation(float rotationAmount)
    {
        verticalRotation = Mathf.Clamp(verticalRotation - rotationAmount, -upDownLookRange, upDownLookRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void HandleRotation()
    {
        float mouseXRotation = playerInputHandler.RotationInput.x * mouseSensitivity;
        float mouseYRotation = playerInputHandler.RotationInput.y * mouseSensitivity;

        ApplyHorizontalRotation(mouseXRotation);
        ApplyVerticalRotation(mouseYRotation);
    }


}
