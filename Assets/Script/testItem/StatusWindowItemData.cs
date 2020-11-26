using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アイテムデータ表示クラス

public class StatusWindowItemData : MonoBehaviour
{
    // アイテムの画像
    private Sprite itemSprite;
    // アイテムの名前
    private string itemName;
    // アイテムのタイプ
    private StatusWindowItemDataBase.Item itemType;
    // アイテムの情報
    private string itemFormation;

    public StatusWindowItemData(Sprite image,string itemName, StatusWindowItemDataBase.Item itemType, string information)
    {
        this.itemSprite = image;
        this.itemName = itemName;
        this.itemType = itemType;
        this.itemFormation = information;
    }
    // 画像取得関数
    public Sprite GetItemSprite()
    {
        return itemSprite;
    }
    // アイテム名取得関数
    public string GetItemName()
    {
        return itemName;
    }
    // アイテムのタイプ取得関数
    public StatusWindowItemDataBase.Item GetItemType()
    {
        return itemType;
    }
    // アイテム情報取得関数
    public string GetItemInformation()
    {
        return itemFormation;
    }

}
