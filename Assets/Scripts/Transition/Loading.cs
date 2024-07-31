using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    Show show;
    public TextMeshProUGUI TextHint;
    public string[] hint;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        show = GameObject.Find("Land").GetComponent<Show>();
        i = Random.Range(0,hint.Length);
        Debug.Log(i);
        TextHint.text = hint[i];
        StartCoroutine(lo());
    }
    public IEnumerator lo()
    {
        yield return new WaitForSeconds(3);
        show.Nextscene();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Main");
    }
}
