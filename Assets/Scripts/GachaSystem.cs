using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GachaSystem : MonoBehaviour
{
    public List<Item> items;
    public TMP_Text resultText;
    public Button drawOneButton;
    public Button drawTenButton;

    public TMP_Text itemAText;
    public TMP_Text itemBText;
    public TMP_Text itemCText;
    public TMP_Text coinText; // 현재 코인을 표시할 UI 텍스트

    private SaveAndLoad saveAndLoad;
    private AudioSource GatchaSEF;

    void Start()
    {
        GatchaSEF = GetComponents<AudioSource>()[1];
        saveAndLoad = FindObjectOfType<SaveAndLoad>();

        items = new List<Item> // 아이템 설정
        {
            new Item("용하의 뜨끈한 국밥집의 추억"),
            new Item("민트초코가지의 생명의 줄기"),
            new Item("강력한 마력이 담긴 ON출석부")
        };

        drawOneButton.onClick.AddListener(() => TryDrawPieces(1));
        drawTenButton.onClick.AddListener(() => TryDrawPieces(10));

        // 세이브 데이터를 불러옵니다
        saveAndLoad.LoadData();

    }

    private void Update()
    {
        // UI를 업데이트합니다.
        UpdateItemUI();    
    }

    private void TryDrawPieces(int numberOfDraws) // 아이템 뽑기 시도
    {
        int cost = numberOfDraws == 1 ? 100 : 1000; // 1개 뽑기는 100원, 10개 뽑기는 1000원

        if (saveAndLoad.data.Coin >= cost)
        {
            saveAndLoad.data.Coin -= cost; // 코인 소모
            DrawPieces(numberOfDraws);
            GatchaSEF.Play();
        }
        else
        {
            resultText.text = "코인이 부족합니다!";
        }

        UpdateItemUI();
    }

    public void DrawPieces(int numberOfDraws) // 아이템 뽑기 
    {
        string result = "뽑기 결과:\n";
        for (int i = 0; i < numberOfDraws; i++)
        {
            int randomIndex = Random.Range(0, items.Count);
            Item drawnItem = items[randomIndex];

            switch (randomIndex)
            {
                case 0:
                    saveAndLoad.data.ItemA_Pieces++;
                    if (saveAndLoad.data.ItemA_Pieces >= 3)
                    {
                        result += $"{drawnItem.itemName} 조각을 뽑았습니다\n";
                        result += $"{drawnItem.itemName} 아이템을 완성했습니다!\n";
                        saveAndLoad.data.ItemA_Pieces -= 3;
                        saveAndLoad.data.HpItem++;
                        saveAndLoad.data.MAXHP += 1; // 예시: HP 증가
                    }
                    else
                    {
                        result += $"{drawnItem.itemName} 조각을 뽑았습니다\n";
                    }
                    break;
                case 1:
                    saveAndLoad.data.ItemB_Pieces++;
                    if (saveAndLoad.data.ItemB_Pieces >= 3)
                    {
                        result += $"{drawnItem.itemName} 조각을 뽑았습니다\n";
                        result += $"{drawnItem.itemName} 아이템을 완성했습니다!\n";
                        saveAndLoad.data.ItemB_Pieces -= 3;
                        saveAndLoad.data.AtkItem++;
                        saveAndLoad.data.ATK += 0.1f; // 예시: ATK 증가
                    }
                    else
                    {
                        result += $"{drawnItem.itemName} 조각을 뽑았습니다\n";
                    }
                    break;
                case 2:
                    saveAndLoad.data.ItemC_Pieces++;
                    if (saveAndLoad.data.ItemC_Pieces >= 3)
                    {
                        result += $"{drawnItem.itemName} 조각을 뽑았습니다\n";
                        result += $"{drawnItem.itemName} 아이템을 완성했습니다!\n";
                        saveAndLoad.data.ItemC_Pieces -= 3;
                        saveAndLoad.data.DefItem++;
                        saveAndLoad.data.Def += 0.1f; // 예시: Def 증가
                    }
                    else
                    {
                        result += $"{drawnItem.itemName} 조각을 뽑았습니다\n";
                    }
                    break;
            }
            saveAndLoad.SaveData();
        }

        resultText.text = result;
    }

    void UpdateItemUI() // 현재 아이템 갯수와 코인 알려주는 작업
    {
        itemAText.text = $"용하의 뜨끈한 국밥집의 추억 - 조각: {saveAndLoad.data.ItemA_Pieces} / 3, 완성된 아이템: {saveAndLoad.data.HpItem}";
        itemBText.text = $"민트초코가지의 생명의 줄기 - 조각: {saveAndLoad.data.ItemB_Pieces} / 3, 완성된 아이템: {saveAndLoad.data.AtkItem}";
        itemCText.text = $"강력한 마력이 담긴 ON출석부 - 조각: {saveAndLoad.data.ItemC_Pieces} / 3, 완성된 아이템: {saveAndLoad.data.DefItem}";
        coinText.text = $"코인: {saveAndLoad.data.Coin}"; // 현재 코인 표시
    }
}

[System.Serializable]
public class Item // 아이템 조각 3개 모으면 완성 아이템 바꿔주는 시스템
{
    public string itemName;

    public Item(string name)
    {
        itemName = name;
    }
}
