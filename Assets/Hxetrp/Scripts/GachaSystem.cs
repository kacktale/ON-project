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

    void Start()
    {
        items = new List<Item> // 아이템 설정
        {
            new Item("용하의 뜨끈한 국밥집의 추억", 3),
            new Item("민트초코가지의 생명의 줄기", 3),
            new Item("강력한 마력이 담긴 ON출석부", 3)
        };

        drawOneButton.onClick.AddListener(() => DrawPieces(1));
        drawTenButton.onClick.AddListener(() => DrawPieces(10));

        UpdateItemUI();
    }

    public void DrawPieces(int numberOfDraws) // 아이템 뽑기 
    {
        string result = "뽑기 결과:\n";
        for (int i = 0; i < numberOfDraws; i++)
        {
            int randomIndex = Random.Range(0, items.Count);
            items[randomIndex].currentPieces++;
            result += $"{items[randomIndex].itemName} 조각을 뽑았습니다\n";

            if (items[randomIndex].CanCraft())
            {
                result += $"{items[randomIndex].itemName} 아이템을 완성했습니다!\n";
                items[randomIndex].currentPieces = 0; // 조각 초기화
                items[randomIndex].completedItems++; // 완성된 아이템 수 증가
            }
        }

        resultText.text = result;
        UpdateItemUI();
    }

    void UpdateItemUI() // 현재 아이템 갯수 알려주는 작업
    {
        itemAText.text = $"용하의 뜨끈한 국밥집의 추억 - 조각: {items[0].currentPieces} / {items[0].pieceCount}, 완성된 아이템: {items[0].completedItems}";
        itemBText.text = $"민트초코가지의 생명의 줄기 - 조각: {items[1].currentPieces} / {items[1].pieceCount}, 완성된 아이템: {items[1].completedItems}";
        itemCText.text = $"강력한 마력이 담긴 ON출석부 - 조각: {items[2].currentPieces} / {items[2].pieceCount}, 완성된 아이템: {items[2].completedItems}";
    }
}

[System.Serializable]
public class Item // 아이템 조각 3개 모으면 완성 아이템 바꿔주는 시스템
{
    public string itemName;
    public int pieceCount;
    public int currentPieces;
    public int completedItems;

    public Item(string name, int count)
    {
        itemName = name;
        pieceCount = count;
        currentPieces = 0;
        completedItems = 0;
    }

    public bool CanCraft()
    {
        return currentPieces >= pieceCount;
    }
}