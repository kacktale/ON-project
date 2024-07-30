using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillImage : MonoBehaviour
{
    SaveAndLoad SNL;
    Image BTN;
    AudioSource m_AudioSource;
    public Transform Transform;
    public bool Ispressd = false;
    // Start is called before the first frame update
    void Start()
    {
        BTN = GameObject.Find("Skil_Button").GetComponent<Image>();
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        m_AudioSource = GameObject.Find("S_Image").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator transition()
    {
        BTN.color = new Color(1, 1, 1, 0.4f);
        transform.DOLocalMove(new Vector3(-1541, -634, 0), 0);
        m_AudioSource.Play();
        transform.DOLocalMove(new Vector3(-622, 288, 0), 0.5f).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(1.5f);
        transform.DOLocalMove(new Vector3(202, 1112, 0), 0.5f).SetEase(Ease.OutQuint);
        yield return new WaitForSeconds(10.5f);
        Ispressd = false;
    }
    public IEnumerator C_transition()
    {
        Transform.DOLocalMove(new Vector3(264, 1154, 0), 0);
        Transform.DOLocalMove(new Vector3(-622, 288, 0), 0.5f).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(1.5f);
        Transform.DOLocalMove(new Vector3(-1514, -604, 0), 0.5f).SetEase(Ease.OutQuint);
        SNL.data.Atk_Speed /= 2;
        yield return new WaitForSeconds(3.5f);
        SNL.data.Atk_Speed *= 2;
        yield return new WaitForSeconds(7);
        BTN.color = Color.white;
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
