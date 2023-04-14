using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == false)
        {
            Debug.Log("Collided with " + other.gameObject.name);
            return;
        }

        //collided with player
        Debug.Log("Collided with player");
        MovementScript moveScript = other.GetComponent<MovementScript>();

        if (moveScript != null)
        {
            Debug.Log("Calling function");
            moveScript.ResetPos();
        }
    }
}
