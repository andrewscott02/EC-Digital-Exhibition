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

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (capsule != null)
            capsule.SetActive(visibleOnStart);
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

        controller.Move(moveVector);
    }
}
