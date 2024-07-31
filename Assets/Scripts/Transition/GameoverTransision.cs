using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverTransision : MonoBehaviour
{
    public RectTransform Gamover, but;
    public GameObject BTN1, BTN2;
    // Start is called before the first frame update
    void Start()
    {
        BTN1.SetActive(false);
        BTN2.SetActive(false);
        Invoke("Gamoverapear", 1.3f);
    }
    void Gamoverapear()
    {
        Gamover.DOMoveX(-1.78f, 0.3f).SetEase(Ease.InQuint);
        Invoke("Butappear", 1.3f);
    }
    void Butappear()
    {
        but.DOMoveX(-2.49f, 0.3f).SetEase(Ease.InQuint);
        Invoke("BTN1appear", 1.3f);
    }
    void BTN1appear()
    {
        BTN1.SetActive(true);
        BTN2.SetActive(true);
    }
    public void StillPlay()
    {
        SceneManager.LoadScene("Main");
    }
    public void Quitting()
    {
        Application.Quit();
    }
}
