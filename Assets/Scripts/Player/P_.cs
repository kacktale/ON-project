using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_ : MonoBehaviour
{
    SkillImage Skillauto;
    SpriteRenderer spriteRenderer;
    SaveAndLoad SNL;
    [Header("����(�����Ұ�)")]
    public float P_Hp;
    public float P_EXP;
    public float P_atkspeed;
    public float P_CURAtkSpeed;
    public float P_ATK;
    public float P_DEF;
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
        P_DEF = SNL.data.Def;

        if(P_Hp <= 0)
        {
            SNL.data.HP = 20;
            SNL.data.MAXHP = 20;
            SNL.data.Exp = 0;
            SNL.data.LVUpExp = 100;
            SNL.data.ATK = 1f;
            SNL.data.LV = 1;
            SNL.data.Atk_Speed = 1.2f;
            SNL.data.CUR_Atk_speed = 1.2f;
            SNL.data.Coin = 0;
            SNL.data.ItemA_Pieces = 0;
            SNL.data.ItemB_Pieces = 0;
            SNL.data.ItemC_Pieces = 0;
            SNL.data.IsSkilCool = false;
            SceneManager.LoadScene("GameOver");
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
