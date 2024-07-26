using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySc : MonoBehaviour
{
    [Header("�÷��̾� �ν�")]
    SaveAndLoad SNL;
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

    // Start is called before the first frame update
    void Awake()
    {
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
            SNL.data.HP -= SNL.data.LV;
            E_AtkSpeed = E_MaxAtkSpeed;
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
        if (SNL.data.CUR_Atk_speed <= 0)
        {
            SNL.data.CUR_Atk_speed = SNL.data.Atk_Speed;
            E_HP -= SNL.data.ATK;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsTouched = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsTouched = false;
    }
}
