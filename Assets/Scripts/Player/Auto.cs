using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auto : MonoBehaviour
{
    P_ Player;
    public Image SpriteRenderer;
    public Sprite waeif;
    public Sprite aefnio;
    bool Is = false;

    private void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<P_>();
    }

    public void Spritechange()
    {
        if (!Is)
        {
            SpriteRenderer.sprite = waeif;
            Player.IsAuto = false;
            Is = true;
        }
        else
        {
            SpriteRenderer.sprite = aefnio;
            Player.IsAuto = true;
            Is = false;
        }
    }
}
