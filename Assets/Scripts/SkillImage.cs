using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillImage : MonoBehaviour
{
    AudioSource m_AudioSource;
    public Transform Transform;
    public bool Ispressd = false;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GameObject.Find("S_Image").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator transition()
    {
        transform.DOLocalMove(new Vector3(-1541, -634, 0), 0);
        m_AudioSource.Play();
        transform.DOLocalMove(new Vector3(-622, 288, 0), 0.5f).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(1.5f);
        transform.DOLocalMove(new Vector3(202, 1112, 0), 0.5f).SetEase(Ease.OutQuint);
        Ispressd = false;
    }
    IEnumerator C_transition()
    {
        Transform.DOLocalMove(new Vector3(264, 1154, 0), 0);
        Transform.DOLocalMove(new Vector3(-622, 288, 0), 0.5f).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(1.5f);
        Transform.DOLocalMove(new Vector3(-1514, -604, 0), 0.5f).SetEase(Ease.OutQuint);
        Ispressd = false;
    }
   public void skill()
    {
        if (!Ispressd)
        {
            Ispressd =true;
            StartCoroutine(transition());
            StartCoroutine(C_transition());
        }
    }
}
