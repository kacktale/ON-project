using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ : MonoBehaviour
{
    SaveAndLoad SNL;
    [Header("스탯(수정불가)")]
    public float P_Hp;
    public float P_EXP;
    public float P_atkspeed;

    private void Awake()
    {
       SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }
    // Update is called once per frame
    void Update()
    {
        P_Hp = SNL.data.HP;
        P_EXP = SNL.data.Exp;
        P_atkspeed = SNL.data.CUR_Atk_speed;

        if(P_Hp <= 0)
        {
            SNL.data.HP = SNL.data.MAXHP;
        }
    }
}
