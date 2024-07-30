using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public int EnemySpawnCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        E_SPawn();
    }
    void E_SPawn()
    {
        if(EnemySpawnCount < 5)
        {
            Debug.Log("적이 생성되었습니다. 누적 생성 횟수 : " + EnemySpawnCount);
            Instantiate(Enemy, transform.position, Quaternion.identity);
            EnemySpawnCount++;
            Invoke("E_SPawn", 1);
        }
        else
        {
            Debug.Log("5번 생성이 었습니다. 20초의 휴식을 가지세요");
            EnemySpawnCount = 0;
            Invoke("E_SPawn", 20);
        }
    }
}
