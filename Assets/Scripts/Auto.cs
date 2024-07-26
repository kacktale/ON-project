using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auto : MonoBehaviour
{
    public Image SpriteRenderer;
    public Sprite waeif;
    public Sprite aefnio;
    bool Is = false;

    public void Spritechange()
    {
        if (!Is)
        {
            SpriteRenderer.sprite = waeif;
            Is = true;
        }
        else
        {
            SpriteRenderer.sprite = aefnio;
            Is = false;
        }
    }
}
