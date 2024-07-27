using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySc : MonoBehaviour
{
    [Header("플레이어 인식")]
    SaveAndLoad SNL;
    public SpriteRenderer PlayerAlpha;
    public Transform P_position;
    [Header("적 설정")]
    public bool IsTouched = false;//적 인식
    public float m_speed = 0.1f;//적 이속
    float E_HP = 10f;//적 현재 피
    public float E_MaxHP = 10f;//적 최대 피
    float E_AtkSpeed = 1.5f;//적 공격속도
    public float E_MaxAtkSpeed = 1.5f;//적 최대 공격속도
    public float E_Exp = 30;//적 경험치
    public float E_coin = 10;//적 코인
    SpriteRenderer E_alpha;

    // Start is called before the first frame update
    void Awake()
    {
        E_alpha = GetComponent<SpriteRenderer>();
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }
    private void Start()
    {
        E_MaxHP += SNL.data.LV;
        E_HP += SNL.data.LV;
        E_coin += SNL.data.LV * 2;
        E_Exp += SNL.data.LV;
        E_AtkSpeed = E_MaxAtkSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //인식 후 멈춤
        if (transform.position.x <= P_position.position.x + 3 || IsTouched)
        {
            IsTouched = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, P_position.position, m_speed);
        }
        //적 공격
        if(E_AtkSpeed <= 0)
        {
            SNL.data.HP -= SNL.data.LV;
            E_AtkSpeed = E_MaxAtkSpeed;
            P_DMG();
        }
        else if(E_AtkSpeed > 0 && IsTouched)
        {
            E_AtkSpeed -= Time.deltaTime;
        }
        if(E_HP <= 0)
        {
            SNL.data.Exp += E_Exp;
            Destroy(gameObject);
        }
        //플레이어 공격
        if (SNL.data.CUR_Atk_speed <= 0)
        {
            SNL.data.CUR_Atk_speed = SNL.data.Atk_Speed;
            E_HP -= SNL.data.ATK;
            E_DMG();
            Debug.Log(E_HP);
        }
        else
        {
            SNL.data.CUR_Atk_speed -= Time.deltaTime;
        }
        //적 4망
        if (E_HP <= 0)
        {
            SNL.data.Coin += E_coin;
            SNL.data.HP += 2;
            SNL.data.Exp += E_Exp;
            Destroy(gameObject);
        }
    }
    public void P_DMG()
    {
        PlayerAlpha.color = new Color(255,0,0);
        Invoke("P_OFFDMG", 0.5f);
    }
    void P_OFFDMG()
    {
        PlayerAlpha.DOColor(new Color(255,255,255),0.5f);//놀랍게도 서서히 안됨 WA!
    }
    public void E_DMG()
    {
        E_alpha.color = new Color(255, 0, 0);
        Invoke("E_OFFDMG", 0.5f);
    }
    void E_OFFDMG()
    {
        E_alpha.color = Color.white;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsTouched = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsTouched = false;
    }
}
