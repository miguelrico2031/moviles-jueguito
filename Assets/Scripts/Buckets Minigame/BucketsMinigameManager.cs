using UnityEngine;
using System;

public class BucketsMinigameManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer targetColorSprite;
    [SerializeField] private RGB255 targetColor;

    [SerializeField] private SpriteRenderer guessColorSprite;
    [SerializeField] private RGB255 guessColor;

    private static readonly RGB255 RED = new RGB255(255, 0, 0);
    private static readonly RGB255 YELLOW = new RGB255(255, 255, 0);
    private static readonly RGB255 BLUE = new RGB255(0, 0, 255);

    void Start()
    {
        targetColor = RGB255.Random();
        targetColorSprite.color = targetColor.ToColor();

        guessColor = new RGB255(255, 255, 255);
        guessColorSprite.color = guessColor.ToColor();
    }

    public void MixColor(RGB255 colorToMix)
    {
        if (colorToMix.ToColor() == RED.ToColor())
        {
            Debug.Log("red");
            MixSubtractiveColor(guessColor, RED);
            guessColorSprite.color = guessColor.ToColor();
        }
        else if (colorToMix.ToColor() == YELLOW.ToColor())
        {
            Debug.Log("yellow");
            MixSubtractiveColor(guessColor, YELLOW);
            guessColorSprite.color = guessColor.ToColor();
        }
        else if (colorToMix.ToColor() == BLUE.ToColor())
        {
            Debug.Log("blue");
            MixSubtractiveColor(guessColor, BLUE);
            guessColorSprite.color = guessColor.ToColor();
        }
        else if (colorToMix.ToColor() == Color.white)
        {
            Debug.Log("white");
            guessColor.R = byte.MaxValue;
            guessColor.G = byte.MaxValue;
            guessColor.B = byte.MaxValue;
            guessColorSprite.color = guessColor.ToColor();
        }
        /*
        if (colorToMix.ToColor() == Color.red)
        {
            Debug.Log("red");
            guessColor.G = (byte)Math.Max(0, (int)guessColor.G - 1);
            guessColor.B = (byte)Math.Max(0, (int)guessColor.B - 1);
            guessColorSprite.color = guessColor.ToColor();
        }
        else if (colorToMix.ToColor() == Color.green)
        {
            Debug.Log("green");
            guessColor.R = (byte)Math.Max(0, (int)guessColor.R - 1);
            guessColor.B = (byte)Math.Max(0, (int)guessColor.B - 1);
            guessColorSprite.color = guessColor.ToColor();
        }
        else if (colorToMix.ToColor() == Color.blue)
        {
            Debug.Log("blue");
            guessColor.R = (byte)Math.Max(0, (int)guessColor.R - 1);
            guessColor.G = (byte)Math.Max(0, (int)guessColor.G - 1);
            guessColorSprite.color = guessColor.ToColor();
        }
        else if (colorToMix.ToColor() == Color.white)
        {
            Debug.Log("white");
            guessColor.R = byte.MaxValue;
            guessColor.G = byte.MaxValue;
            guessColor.B = byte.MaxValue;
            guessColorSprite.color = guessColor.ToColor();
        }
        */
    }

    private void MixSubtractiveColor(RGB255 currentColor, RGB255 colorToAdd)
    {
        float amount = 0.01f;

        float r = currentColor.R / 255f;
        float g = currentColor.G / 255f;
        float b = currentColor.B / 255f;

        float colorR = colorToAdd.R / 255f;
        float colorG = colorToAdd.G / 255f;
        float colorB = colorToAdd.B / 255f;

        r = Mathf.Max(0f, r + (colorR - 1f) * amount);
        g = Mathf.Max(0f, g + (colorG - 1f) * amount);
        b = Mathf.Max(0f, b + (colorB - 1f) * amount);

        guessColor.R = (byte)(r * 255);
        guessColor.G = (byte)(g * 255);
        guessColor.B = (byte)(b * 255);
    }

    void Update()
    {
        Debug.Log($"R{guessColor.R}, G{guessColor.G}, B{guessColor.B}");
    }
}
