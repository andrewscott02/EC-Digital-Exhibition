using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTime : MonoBehaviour
{
    public float debugValue = 1;
    public float speed = 0.4f;
    public Vector2 limits = new Vector2
    {
        x = -1.28f,
        y = 0
    };
    float currentTime = 0;
    bool advancing = true;

    Material mat;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float addTime = advancing ? speed * Time.deltaTime : -speed * Time.deltaTime;

        currentTime = Mathf.Clamp(currentTime + addTime, limits.x, limits.y);

        if (currentTime == limits.x)
            advancing = true;
        else if (currentTime == limits.y)
            advancing = false;

        mat.SetFloat("_DissolveTime", currentTime);
    }
}
