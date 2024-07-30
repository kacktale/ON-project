using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ : MonoBehaviour
{
    SkillImage Skillauto;
    SpriteRenderer spriteRenderer;
    SaveAndLoad SNL;
    [Header("스탯(수정불가)")]
    public float P_Hp;
    public float P_EXP;
    public float P_atkspeed;
    public float P_CURAtkSpeed;
    public float P_ATK;
    public bool IsAuto = true;

    private void Awake()
    {
        Skillauto = GameObject.Find("S_Image").GetComponent<SkillImage>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }
    // Update is called once per frame
    void Update()
    {
        P_Hp = SNL.data.HP;
        P_EXP = SNL.data.Exp;
        P_atkspeed = SNL.data.Atk_Speed;
        P_CURAtkSpeed = SNL.data.CUR_Atk_speed;
        P_ATK = SNL.data.ATK;

        if(P_Hp <= 0)
        {
            SNL.data.HP = SNL.data.MAXHP;
        }
        if (IsAuto)
        {
            if (!Skillauto.Ispressd)
            {
                Skillauto.Ispressd = true;
                StartCoroutine(Skillauto.transition());
                StartCoroutine(Skillauto.C_transition());
            }
        }
    }
    public void P_DMG()
    {
        spriteRenderer.color = new Color(255, 0, 0);
        Invoke("P_OFFDMG", 0.5f);
    }
    void P_OFFDMG()
    {
        spriteRenderer.color = Color.white;
    }
}
