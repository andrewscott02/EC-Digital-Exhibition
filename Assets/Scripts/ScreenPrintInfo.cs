using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPrintInfo : MonoBehaviour
{
    public string Title, Artist, Dimensions, Year, Medium;
    public Sprite QRCode, Interview;

    bool open = false;

    public void Interact()
    {
        open = !open;
        Debug.Log(Title + " is " + open);
    }
}