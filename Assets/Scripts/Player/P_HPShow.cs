using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_HPShow : MonoBehaviour
{
    public Slider Slider;
    SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = SNL.data.HP / SNL.data.MAXHP;
    }
}
