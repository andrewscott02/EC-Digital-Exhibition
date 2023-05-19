using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasInfo : MonoBehaviour
{
    public static CanvasInfo Instance;
    public GameObject interactPopup, infoCanvas, poem, intro;

    private void Start()
    {
        Instance = this;
        interactPopup.SetActive(false);
        infoCanvas.SetActive(false);
        poem.SetActive(false);
        intro.SetActive(false);
    }

    public TextMeshProUGUI title, artist, medium, date, dimensions;
    public Image image, qr;

    public void Interact(ScreenPrintInfo info)
    {
        if (info == null)
        {
            return;
        }

        title.text = "Title: " + info.Title;
        artist.text = "Artist: " + info.Artist;
        medium.text = "Medium; " + info.Medium;
        date.text = "Year: " + info.Year;
        dimensions.text = "Dimensions: " + info.Dimensions;
        image.sprite = info.Interview;
        qr.sprite = info.QRCode;
    }

    public void InteractPopup(bool open)
    {
        bool canvasOpen = poem.activeSelf == true || intro.activeSelf == true || infoCanvas.activeSelf == true;

        interactPopup.SetActive(open &! canvasOpen);
    }

    private void Update()
    {
        if (infoCanvas.activeSelf)
            interactPopup.SetActive(false);
        if (intro.activeSelf)
            interactPopup.SetActive(false);
        if (poem.activeSelf)
            interactPopup.SetActive(false);
    }
}
