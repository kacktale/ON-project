using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStop : MonoBehaviour
{
    AudioSource audo;
    // Start is called before the first frame update
    void Start()
    {
        audo= GetComponent<AudioSource>();
    }

    public void StartAudi()
    {
        audo.Play();
    }
    public void PauseAudi()
    {
        audo.Pause();
    }
}
