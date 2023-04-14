using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    CharacterController controller;
    public GameObject capsule;
    public bool visibleOnStart = true;

    public float speed = 0.01f;
    public float gravity = 0.015f;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (capsule != null)
            capsule.SetActive(visibleOnStart);

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveVector -= transform.right;
        }

        moveVector.Normalize();
        moveVector *= speed;
        moveVector.y -= gravity;

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
