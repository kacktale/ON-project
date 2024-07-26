using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamStartMove : MonoBehaviour
{
    public 
    Camera cam;
    Transform camT;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        camT = GetComponent<Transform>();
        cam.orthographicSize = 1;
        camT.position = new Vector3(-7.71f, -2.28f, -10f);
        camT.DOLocalMove(new Vector3(0,0,-10),2).SetEase(Ease.OutQuint);
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.orthographicSize >= 5)
        {
            cam.orthographicSize = 5;
            return;
        }
        {
            cam.orthographicSize += Time.deltaTime * 2;
        }
    }
}
