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
            Debug.Log("���� �����Ǿ����ϴ�. ���� ���� Ƚ�� : " + EnemySpawnCount);
            Instantiate(Enemy, transform.position, Quaternion.identity);
            EnemySpawnCount++;
            Invoke("E_SPawn", 1);
        }
        else
        {
            Debug.Log("5�� ������ �����ϴ�. 20���� �޽��� ��������");
            EnemySpawnCount = 0;
            Invoke("E_SPawn", 20);
        }
    }
}
