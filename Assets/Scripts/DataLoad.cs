using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataLoad : MonoBehaviour
{
    public TextMeshProUGUI Player, coins,P_LV;
    SaveAndLoad SNL;
    // Start is called before the first frame update
    void Start()
    {
        SNL = GetComponent<SaveAndLoad>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        P_LV.text = SNL.data.LV.ToString("N0") + ".LV";
        Player.text = SNL.data.PlayerName;
        coins.text = SNL.data.Coin.ToString("N0");
    }
}
