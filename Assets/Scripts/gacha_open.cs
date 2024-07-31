using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class gacha_open : MonoBehaviour
{
    AudioStop audioStop;
    AudioSource GatchaBGM;
    public GameObject Gacha_panel;
    private Vector3 targetPos = new Vector3 (0, 40, 0);
    // Start is called before the first frame update
    void Start()
    {
        audioStop = FindAnyObjectByType<AudioStop>();
        GatchaBGM = GetComponent<AudioSource>();
        Gacha_panel.SetActive(false);
    }

    // Update is called once per frame

    public void open_gacha()
    {
        audioStop.PauseAudi();
        Gacha_panel.SetActive(true);
        GatchaBGM.Play();
    }

    public void close_gacha()
    {
        audioStop.StartAudi();
        Gacha_panel.SetActive(false);
        GatchaBGM.Stop();
    }
}
