using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public float ATK = 1f;
    public int LV = 1;
    public float HP = 20;
    public float MAXHP = 20;
    public float Exp = 0;
    public float LVUpExp = 100;
    public float Atk_Speed = 1.2f;
    public float CUR_Atk_speed = 1.2f;
    public float Coin;
    public string PlayerName;
    public bool IsAtkItem = false;
    public bool IsDefItem = false;
    public bool IsSkilCool = false;
    public bool IsSkiIitem = false;
    public bool IsSkilitem1 = false;
    public int AtkItem = 0;
    public int DefItem = 0;
    public int SkilCool = 0;
    public bool IsSaveCreated = false;
}

public class SaveAndLoad : MonoBehaviour
{
    public SaveData data = new SaveData();
    private string SAVE_DATA_DIRECTORY;
    private string SAVE_FILE_NAME = "/SaveFile.txt";
    public float timescale = 1f;
    // Start is called before the first frame update
    void Start()
    {
        data.Atk_Speed = 1.2f;
        data.CUR_Atk_speed = 1.2f;
        SAVE_DATA_DIRECTORY = Application.dataPath + "/Saves/";
        LoadData();
    }

    public void SaveData()
    {

        // 게임 데이터 저장
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(SAVE_DATA_DIRECTORY + SAVE_FILE_NAME, json);
    }

    public void LoadData()
    {
        // 게임 데이터 로드
        if (File.Exists(SAVE_DATA_DIRECTORY + SAVE_FILE_NAME))
        {
            string loadJson = File.ReadAllText(SAVE_DATA_DIRECTORY + SAVE_FILE_NAME);
            data = JsonUtility.FromJson<SaveData>(loadJson);

            Debug.Log("로드 완료");
            Debug.Log(loadJson);
        }
        else
        {
            Debug.Log("세이브 파일이 없습니다");
        }
    }

    public void Starting()
    {
        if (!Directory.Exists(SAVE_DATA_DIRECTORY))
        {
            Directory.CreateDirectory(SAVE_DATA_DIRECTORY);
            data.IsSaveCreated = true;
            SaveData();
        }
    }
    public void ResetData()
    {
        // 데이터 초기화
        data = new SaveData();

        Debug.Log("데이터 리셋 완료");
        data.IsSaveCreated = false;
        SceneManager.LoadScene("CreatePlayerName");
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu" || SceneManager.GetActiveScene().name == "CreatePlayerName")
        {

        }
        else
        {
            SaveData();
        }
        if (data.HP > data.MAXHP)
        {
            data.HP = data.MAXHP;
        }
        if (data.AtkItem >= 100)
        {
            data.IsAtkItem = true;
        }
        if(data.DefItem >= 100)
        {
            data.IsDefItem = true;
        }
        if(data.SkilCool >= 100)
        {
            data.IsSkilCool = true;
        }
        if(data.Exp >= data.LVUpExp)
        {
            data.LV++;
            data.LVUpExp += data.Exp;
            data.Exp = 0;
            data.MAXHP += 12;
            data.HP = data.MAXHP;
            data.ATK++;
        }
    }
}
