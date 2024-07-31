using DG.Tweening;
using System.Collections;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy_Prefab; // 적 프리팹
    public TMP_Text Stage_Text; // 스테이지 시작시 나오는 텍스트
    public TMP_Text Stage_Timer; // 남은 스테이지 타임 표시 
    public GameObject Next_Text; // GOOD 나중에 수정
    public int Stage_Num = 1; // 표시되는 스테이지 넘버
    public float Stage_Time = 10; // 한 스테이지 당 타임
    public float Ready_Time = 2.5f;
    private bool End_Stage = false; // 스테이지가 끝났는가

     private SaveAndLoad SNL;

    public Ease ease;

    // Start is called before the first frame update
    void Start()
    {
        SNL = FindAnyObjectByType<SaveAndLoad>();
        Next_Text.SetActive(false); // GOOD 제거
        Start_Stage(); // 스테이지 시작 
    }

    // Update is called once per frame
    void Update()
    {
        Stage_Timer.text = "Ready : " + Ready_Time.ToString("F1");  // 다음 스테이지 타이머 표시
        Ready_Time -= Time.deltaTime;
        if (Stage_Time <= 0) // 만약 스테이지 타임이 0이면 다음 스테이지 준비
        {
            End_Stage = true;
            //DestroyAllEnemies(); // 모든 적 제거
            StopCoroutine("SpawnEnemies"); // 적 스폰 멈추기
            Next_Text.SetActive(true); // GOOD 화면에 표시
            Stage_Num++; // 스테이지 넘버 올라감 
            Stage_Time = 10; // 스테이지 시간 초기화
            Invoke("Start_Stage", Ready_Time); // 준비시간 후 다음 스테이지 시작
        }

        if (!End_Stage)// 스테이지가 끝이 아닐때만 시간이 흐른다 
        {
            Ready_Time = 2.5f;
            Stage_Time -= Time.deltaTime;
            Stage_Timer.text = "Next Stage : " + Mathf.Round(Stage_Time);  // 다음 스테이지 타이머 표시
        }
        
        if (Stage_Num > 20) 
        {
            StopCoroutine("SpawnEnemies");
        }
    }

    public void Start_Stage() // 스테이지 시작
    {
        Stage_Text.text = "Stage : " + Stage_Num.ToString(); // 현재 스테이지 표시
        StartCoroutine("SpawnEnemies"); // 적 스폰 시작
        StartCoroutine(Stage_Notice()); // 코루틴 스테이지 표시 애니메이션
        Next_Text.SetActive(false); // GOOD 제거 
        End_Stage = false; // 스테이지 시작
    }

    IEnumerator SpawnEnemies() // 적 랜덤 생성 함수 나중에 랜덤 수정할 예정
    {
        while (true)
        {
            float SpawnTimeMin = 0.3f - (Stage_Num * 0.01f + SNL.data.LV/2f -1);
            if (0.3f - (Stage_Num * 0.01f + SNL.data.LV -1) >= (2f - (Stage_Num * 0.1f)))
            {
                SpawnTimeMin = 2f - (Stage_Num * 0.1f) - 0.1f;
            }
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(SpawnTimeMin, (2f - (Stage_Num * 0.1f)))); // Range 안의 값은 수정 예정
        }
    }

    public void SpawnEnemy() // 적 생성
    {
        Instantiate(Enemy_Prefab, new Vector3(7.3f, -2.25f, 0), Quaternion.identity);
    }

    private void DestroyAllEnemies() // 몬스터 전체 삭제
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // 적 태그 찾아서 배열에 다 집어넣고 
        foreach (GameObject enemy in enemies) // 배열에 있는 것들 다 지우기
        {
            Destroy(enemy);
        }
    }

    IEnumerator Stage_Notice() // 코루틴 애니메이션
    {
        Stage_Text.transform.DOLocalMove(new Vector3(0, 300, 0), 1f).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(2f);
        Stage_Text.transform.DOLocalMove(new Vector3(0, 700, 0), 1f).SetEase(Ease.InQuint);
    }
}
