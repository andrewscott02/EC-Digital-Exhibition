using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    InputManager controls;
    InputAction look;

    public float joystickSensitivity = 2f;
    public Transform playerBody;

    float xRot = 0f;

    private void Awake()
    {
        controls = new InputManager();
    }

    private void OnEnable()
    {
        look = controls.Player.Look;
        look.Enable();

        controls.Player.Look.performed += ctx => Look(ctx.ReadValue<Vector2>() * joystickSensitivity);
        controls.Player.Look.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    Vector2 direction;

    // Update is called once per frame
    void Look(Vector2 direction)
    {
        this.direction = direction;
    }

    private void Update()
    {
        if (!controls.Player.Look.IsPressed())
            direction = Vector3.zero;

        xRot -= direction.y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        playerBody.Rotate(Vector3.up * direction.x);
    }
}
