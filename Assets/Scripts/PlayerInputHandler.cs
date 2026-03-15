using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name Reference")]
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    [SerializeField] private string movement = "Movement";
    [SerializeField] private string rotation = "Rotation";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string action = "Action";
    [SerializeField] private string debugText = "DebugText";
    [SerializeField] private string timer = "Timer";


    private InputAction movementAction;
    private InputAction rotationAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction actionAction;
    private InputAction debugTextAction;
    private InputAction timerAction;


    public Vector2 MovementInput {  get; private set; }
    public Vector2 RotationInput {  get; private set; }
    public bool JumpTriggered {  get; private set; }
    public bool SprintTriggered {  get; private set; }
    public bool ActionTriggered {  get; private set; }
    public bool DebugTextTriggered {  get; private set; }
    public bool TimerTriggered {  get; private set; }

    private void Awake()
    {
        InputActionMap mapReference = playerControls.FindActionMap(actionMapName);

        movementAction = mapReference.FindAction(movement);
        rotationAction = mapReference.FindAction(rotation);
        jumpAction = mapReference.FindAction(jump);
        sprintAction = mapReference.FindAction(sprint);
        actionAction = mapReference.FindAction(action);
        debugTextAction = mapReference.FindAction(debugText);
        timerAction = mapReference.FindAction(timer);

        SubscribeActionValuesToInputEvents();
    }

    private void SubscribeActionValuesToInputEvents()
    {
        movementAction.performed += inputInfo => MovementInput = inputInfo.ReadValue<Vector2>();
        movementAction.canceled += inputInfo => MovementInput = Vector2.zero;

        rotationAction.performed += inputInfo => RotationInput = inputInfo.ReadValue<Vector2>();
        rotationAction.canceled += inputInfo => RotationInput = Vector2.zero;

        jumpAction.performed += inputInfo => JumpTriggered = true;
        jumpAction.canceled += inputInfo => JumpTriggered = false;

        sprintAction.performed += inputInfo => SprintTriggered = true;
        sprintAction.canceled += inputInfo => SprintTriggered = false;

        actionAction.performed += inputInfo => ActionTriggered = true;
        actionAction.canceled += inputInfo => ActionTriggered = false;

        debugTextAction.performed += inputInfo => DebugTextTriggered = true;
        debugTextAction.canceled += inputInfo => DebugTextTriggered = false;

        timerAction.performed += inputInfo => TimerTriggered = true;
        timerAction.canceled += inputInfo => TimerTriggered = false;
    }

    private void OnEnable()
    {
        playerControls.FindActionMap(actionMapName).Enable();
    }

    private void OnDisable()
    {
        playerControls.FindActionMap(actionMapName).Disable();
    }
}
