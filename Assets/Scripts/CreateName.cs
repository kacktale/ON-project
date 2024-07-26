using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateName : MonoBehaviour
{
    CreateNameTextMove createNameTextMove;
    AudioSource LoopPlay;
    Show show;
    SaveAndLoad SNL;
    public GameObject texting;
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        createNameTextMove = GetComponent<CreateNameTextMove>();
        LoopPlay = GetComponents<AudioSource>()[1];
        show = GameObject.Find("Land").GetComponent<Show>();
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
        StartCoroutine(SoundPlay());
        texting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartTexting()
    {
        texting.SetActive(true);
    }
    public void EndTexting()
    {
        StartCoroutine(Eni());
        SNL.Starting();
        texting.SetActive(false);
       SNL.data.PlayerName = inputField.text;
        SNL.data.IsSaveCreated = true;
       SNL.SaveData();
    }
    IEnumerator Eni()
    {
        createNameTextMove.ExitShoosh();
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Loading");
    }
    IEnumerator SoundPlay()
    {
        yield return new WaitForSeconds(1);
        LoopPlay.Play();
        Debug.Log("");
    }
}
