using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Floor Marker Text")]
public class FloorMarkerData : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string infoText;
    [SerializeField] Color color;
    [SerializeField] Texture image;

    public string GetInfoText()
    {
        return infoText;
    }

    public Color GetColor()
    {
        return color;
    }

    public Texture GetImage()
    {
        return image;
    }
}
