using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNameTextMove : MonoBehaviour
{
    bool IsEnd = false;
    bool IsUp = false;
    float STime = 4f;
    public Transform Text1, Text2,ball1,ball2,box;
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    { 
        canvasGroup = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        StartCoroutine(StartGoShoosh());
        box.DOScaleX(3, 0.7f).SetEase(Ease.OutQuint);
        box.DOScaleY(3, 0.7f).SetEase(Ease.OutQuint);
        box.DOScaleZ(3, 0.7f).SetEase(Ease.OutQuint);
        STime = 0f;
    }
    public void ExitShoosh()
    {
        IsEnd = false;
        box.DOScaleX(20, 0.7f).SetEase(Ease.InQuint);
        box.DOScaleY(20, 0.7f).SetEase(Ease.InQuint);
        box.DOScaleZ(20, 0.7f).SetEase(Ease.InQuint);
    }
    IEnumerator StartGoShoosh()
    {
        yield return new WaitForSeconds(1);
        IsEnd = true;
    }
    void text1Up()
    {
        Text1.DOLocalMoveY(-6.6f, 4).SetEase(Ease.InQuint);
    }
    void text1Down()
    {
        Text1.DOLocalMoveY(-2.51f, 4).SetEase(Ease.OutQuint);
    }
    void text2Up()
    {
        Text2.DOLocalMoveY(8.42f, 4).SetEase(Ease.InQuint);
    }
    void text2Down()
    {
        Text2.DOLocalMoveY(4.45f, 4).SetEase(Ease.OutQuint);
    }
    private void Update()
    {
        if(STime <= 0)
        {
            if(IsUp)
            {
                STime = 4;
                text1Down();
                text2Down();
                IsUp = false;
            }
            else
            {
                STime = 4;
                text1Up();
                text2Up();
                IsUp = true;
            }
        }
            STime -= Time.deltaTime;
        ball1.eulerAngles += new Vector3 (0,0,0.5f);
        ball2.eulerAngles += new Vector3(0, 0, 0.5f);
        if (IsEnd)
        {
            canvasGroup.alpha += Time.deltaTime;
        }
        else
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
        }
    }
}
