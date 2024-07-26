using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    bool IsExit = false;
    bool IsInv = false;
    public GameObject Exit;
    public Transform Inv;

    private void Start()
    {
        Exit.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!IsExit)
            {
                Exit.SetActive(true);
                Time.timeScale = 0;
                IsExit = true;
            }
            else
            {
                Exit.SetActive(false);
                Time.timeScale = 1;
                IsExit = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!IsInv)
            {
                Inv.DOLocalMoveY(0,0.5f).SetEase(Ease.OutQuint);
                IsInv = true;
            }
            else
            {
                Inv.DOLocalMoveY(-971, 0.5f).SetEase(Ease.InQuint);
                IsInv = false;
            }
        }
    }
    public void StilPlaying()
    {
        Exit.SetActive(false);
        Time.timeScale = 1;
        IsExit = false;
    }
    public void Exiting()
    {
        Application.Quit();
    }
}
