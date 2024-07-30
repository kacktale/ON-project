using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToStart : MonoBehaviour
{
    public Show show;
    SaveAndLoad SNL;
    public Btn Btn;
    AudioSource click;
    public bool IsLoad = false;
    // Start is called before the first frame update
    void Start()
    {
        show = GameObject.Find("Land").GetComponent<Show>();
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        Btn = GameObject.Find("Btn").GetComponent<Btn>();
        click = GameObject.Find("Click").GetComponents<AudioSource>()[0];
        IsLoad = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBtn()
    {
        StartCoroutine(awefeaf());
        click.Play();
        Debug.Log("와 샌쥬?");
        Btn.BtnType = 1;
        StartCoroutine(Btn.FadeOutUl());
    }
    public void HowToplayBtn()
    {
        StartCoroutine(awefeaf());
        click.Play();
        Debug.Log("와 샌쥬?");
    }
    IEnumerator awefeaf()
    {
        show.Nextscene();
        yield return new WaitForSeconds(0.5f);
    }
    public void ExitBtn()
    {
        click.Play();
        StartCoroutine("wait");
        Btn.BtnType = 0;
        StartCoroutine(Btn.FadeOutUl());
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("와?");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("게임이 종료되었습니다.");
    }

    public void gameStart()
    {
        if (SNL.data.IsSaveCreated)
        { 
            SceneManager.LoadScene("Loading");
            Debug.Log("게임을 불러오고 있습니다.");
        }
        else
        {
            SceneManager.LoadScene("CreatePlayerName");
        }
    }
}
