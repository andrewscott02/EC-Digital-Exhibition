using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    InputManager controls;
    InputAction look;
    InputAction interact;

    public float joystickSensitivity = 2f;
    public Transform playerBody;

    public float interactDistance = 5f;

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

        interact = controls.Player.Interact;
        interact.Enable();

        controls.Player.Interact.performed += ctx => Interact();
        controls.Player.Interact.Enable();
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
        this.direction = LerpV2(this.direction, direction, Time.deltaTime);
    }

    Vector2 LerpV2(Vector2 a, Vector2 b, float t)
    {
        Vector2 vector = new Vector2();

        vector.x = Mathf.Lerp(a.x, b.x, t);
        vector.y = Mathf.Lerp(a.y, b.y, t);

        return vector;
    }

    private void FixedUpdate()
    {
        if (!controls.Player.Look.IsPressed())
            direction = Vector3.zero;

        xRot -= direction.y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        playerBody.Rotate(Vector3.up * direction.x);
    }

    ScreenPrintInfo info = null;
    public LayerMask layerMask;

    private void Update()
    {
        info = null;
        CanvasInfo.Instance.interactPopup.SetActive(false);

        Vector3 dir = transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, interactDistance, layerMask))
        {
            if (hit.collider == null)
            {
                Debug.Log("No collider");
                return;
            }

            info = hit.collider.gameObject.GetComponent<ScreenPrintInfo>();
            Debug.Log(info.name);
        }

        CanvasInfo.Instance.InteractPopup(info != null);
    }

    void Interact()
    {
        Debug.Log("Interact");
        if (info != null)
            info.Interact();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * interactDistance));
    }
}
