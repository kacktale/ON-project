using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTextMove : MonoBehaviour
{
    public Transform Text1, Text2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(text1());
        StartCoroutine(text2());
    }
    IEnumerator text1()
    {
        Text1.DOLocalMoveX(-1.1f, 0);
        Text1.DOLocalMoveX(2.38f, 3);
        yield return null;
    }
    IEnumerator text2()
    {
        Text2.DOLocalMoveX(2.38f, 0);
        Text2.DOLocalMoveX(-1.1f, 3);
        yield return null;
    }

}
