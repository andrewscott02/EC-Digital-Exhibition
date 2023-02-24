using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public GameObject capsule;

    // Start is called before the first frame update
    void Start()
    {
        if (capsule != null)
            capsule.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
