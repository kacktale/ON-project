using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySc : MonoBehaviour
{
    [Header("�÷��̾� �ν�")]
    P_ player;
    SaveAndLoad SNL;
    public SpriteRenderer PlayerAlpha;
    public Transform P_position;
    [Header("�� ����")]
    public bool IsTouched = false;//�� �ν�
    public float m_speed = 0.1f;//�� �̼�
    float E_HP = 10f;//�� ���� ��
    public float E_MaxHP = 10f;//�� �ִ� ��
    float E_AtkSpeed = 1.5f;//�� ���ݼӵ�
    public float E_MaxAtkSpeed = 1.5f;//�� �ִ� ���ݼӵ�
    public float E_Exp = 30;//�� ����ġ
    public float E_coin = 10;//�� ����
    SpriteRenderer E_alpha;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<P_>();
        PlayerAlpha = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        P_position = GameObject.Find("Player").GetComponent<Transform>();
        E_alpha = GetComponent<SpriteRenderer>();
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }
    private void Start()
    {
        E_MaxHP += SNL.data.LV;
        E_HP += SNL.data.LV * 3;
        E_coin += SNL.data.LV * 2;
        E_Exp += SNL.data.LV;
        E_AtkSpeed = E_MaxAtkSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�ν� �� ����
        if (transform.position.x <= P_position.position.x + 3 || IsTouched)
        {
            IsTouched = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, P_position.position, m_speed);
        }
        //�� ����
        if(E_AtkSpeed <= 0)
        {
            SNL.data.HP -= SNL.data.LV - SNL.data.Def;
            E_AtkSpeed = E_MaxAtkSpeed;
            player.P_DMG();
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
        //�÷��̾� ����
        if (SNL.data.CUR_Atk_speed <= 0 && IsTouched)
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
        //�� 4��
        if (E_HP <= 0)
        {
            SNL.data.Coin += E_coin;
            SNL.data.HP += 2;
            SNL.data.Exp += E_Exp;
            Destroy(gameObject);
        }
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
