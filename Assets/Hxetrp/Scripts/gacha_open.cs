using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class gacha_open : MonoBehaviour
{
    public GameObject Gacha_panel;
    public Image Gacha_image;
    private Vector3 targetPos = new Vector3 (0, 40, 0);
    // Start is called before the first frame update
    void Start()
    {
        Gacha_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Gacha_com();
        }
    }

    public void open_gacha()
    {
        Gacha_panel.SetActive(true);
    }

    public void close_gacha()
    {
        Gacha_panel.SetActive(false);
    }
    public void Gacha_com()
    {
        Gacha_image.transform.DOPunchPosition(targetPos, 2, 10, 1, false);
    }
}
