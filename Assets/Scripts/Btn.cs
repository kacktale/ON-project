using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public float BtnType = 0f;
    ClickToStart CTS;
    public CanvasGroup canvasGroup;
    public float fadeDuration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        CTS = GameObject.Find("Click").GetComponent<ClickToStart>();
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeInUI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator FadeInUI()
    {
        float elapsedTime = 0f;
        canvasGroup.alpha = 0f;

        yield return new WaitForSeconds(4.3f);

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }
    }

    public IEnumerator FadeOutUl()
    {
        float fadeTime = 0.9f;
        canvasGroup.alpha = 1f;

        while (fadeTime > 0)
        {
            fadeTime -= Time.deltaTime;
            canvasGroup.alpha = fadeTime;
            yield return null;
        }
        switch (BtnType)
        {
            case 0:
                CTS.Exit(); break;
            case 1:
                CTS.gameStart(); break;
        }
    }
}
