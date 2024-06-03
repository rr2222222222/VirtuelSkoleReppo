using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorMarker : MonoBehaviour
{
    [SerializeField] FloorMarkerData floorMarkerData;
    string infoText;
    Color color;
    RawImage image;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        infoText = floorMarkerData.GetInfoText();
        color = floorMarkerData.GetColor();
        image = GetComponentInChildren<RawImage>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        image.texture = floorMarkerData.GetImage();
        spriteRenderer.color = color;
    }

    public string GetInfoText()
    {
        return infoText;
    }

    public Color GetColor()
    {
        return color;
    }

}
