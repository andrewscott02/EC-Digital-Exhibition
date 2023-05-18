using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    InputManager controls;
    InputAction move;

    CharacterController controller;
    public GameObject capsule;
    public bool visibleOnStart = true;

    public float speed = 0.01f;
    public float gravity = 0.015f;

    Vector3 startPos;

    private void Awake()
    {
        controls = new InputManager();
    }

    private void OnEnable()
    {
        move = controls.Player.Move;
        move.Enable();

        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Player.Move.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (capsule != null)
            capsule.SetActive(visibleOnStart);

        startPos = transform.position;
    }

    Vector3 moveVector;

    // Update is called once per frame
    void Move(Vector2 move)
    {
        Debug.Log("Moving");
        moveVector = Vector3.zero;
        moveVector += Camera.main.transform.forward * move.y;
        moveVector += Camera.main.transform.right * move.x;

        CanvasInfo.Instance.poem.SetActive(false);
        CanvasInfo.Instance.intro.SetActive(false);
        CanvasInfo.Instance.infoCanvas.SetActive(false);
        ScreenPrintInfo.open = false;

        //moveVector.Normalize();
        moveVector *= speed;
    }

    private void FixedUpdate()
    {
        if (!controls.Player.Move.IsPressed())
            moveVector = Vector3.zero;

        moveVector.y = -gravity;

        MovePlayer(moveVector);
    }

    public void MovePlayer(Vector3 moveVector)
    {
        controller.Move(moveVector);
    }

    public void ResetPos()
    {
        Debug.Log("Resetting pos from " + transform.position + " to " + startPos);
        controller.enabled = false;
        transform.position = startPos;
        controller.enabled = true;

        Debug.Log("Reset to " + transform.position);
    }
}
