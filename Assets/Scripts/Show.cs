using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMoveX(2002, 0.5f);
    }
    public void Nextscene()
    {
        Debug.Log("");
        transform.DOLocalMoveX(0, 0.5f);
    }
}
