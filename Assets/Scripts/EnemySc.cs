using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySc : MonoBehaviour
{
    [Header("플레이어 인식")]
    SaveAndLoad SNL;
    public Transform P_position;
    [Header("적 설정")]
    public bool IsTouched = false;
    public float m_speed = 0.1f;
    public float E_HP = 10f;
    float E_MaxHP = 10f;
    public float E_AtkSpeed = 1.5f;
    public float E_Exp = 30;
    public float E_coin = 10;

    // Start is called before the first frame update
    void Start()
    {
        SNL = GameObject.Find("Click").GetComponent<SaveAndLoad>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x <= P_position.position.x + 3 || IsTouched)
        {
            IsTouched = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, P_position.position, m_speed);
        }
        if(E_AtkSpeed <= 0)
        {
            SNL.data.HP -= 1;
            E_AtkSpeed = 1.5f;
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
        if (SNL.data.CUR_Atk_speed <= 0)
        {
            SNL.data.CUR_Atk_speed = SNL.data.Atk_Speed;
            E_HP -= 1;
            Debug.Log(E_HP);
        }
        else
        {
            SNL.data.CUR_Atk_speed -= Time.deltaTime;
        }
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
