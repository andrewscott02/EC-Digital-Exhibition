using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPrintInfo : MonoBehaviour
{
    public string Title, Artist, Dimensions, Year, Medium;
    public Sprite QRCode, Interview;

    public static bool open = false;

    public bool poem = false;
    public bool intro = false;

    public void Interact()
    {
        open = !open;
        Debug.Log(Title + " is " + open);

        CanvasInfo.Instance.poem.SetActive(false);
        CanvasInfo.Instance.intro.SetActive(false);
        CanvasInfo.Instance.infoCanvas.SetActive(false);

        if (poem)
        {
            CanvasInfo.Instance.poem.SetActive(open);
            CanvasInfo.Instance.InteractPopup(!open);
        }
        else if (intro)
        {
            CanvasInfo.Instance.intro.SetActive(open);
            CanvasInfo.Instance.InteractPopup(!open);
        }
        else
        {
            CanvasInfo.Instance.infoCanvas.SetActive(open);
            CanvasInfo.Instance.Interact(this);
        }
    }
}