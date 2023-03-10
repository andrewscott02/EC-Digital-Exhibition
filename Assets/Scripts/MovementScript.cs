using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject capsule;
    public bool visibleOnStart = true;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (capsule != null)
            capsule.SetActive(visibleOnStart);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            //Move forwards
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

        rb.AddForce(moveVector * speed, ForceMode.Force);
    }
}
