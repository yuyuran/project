using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アイテムデータ管理クラス
public class StatusWindowItemDataBase : MonoBehaviour
{
    // アイテムの種類
    public enum Item
    {
        AttackUP,  // 攻撃力アップ
        VelUP      // 速度アップ
    };

    // アイテム所持数
    private StatusWindowItemData[] itemsList = new StatusWindowItemData[2];

    // アイテム情報管理関数
    private void Awake()
    {
        itemsList[0] = new StatusWindowItemData(Resources.Load("Attack") as Sprite, "攻撃アップ", Item.AttackUP, "攻撃力上昇");
        itemsList[1] = new StatusWindowItemData(Resources.Load("VelUP") as Sprite, "速度アップ", Item.VelUP, "移動速度上昇");

    }

    // アイテム情報取得関数
    public StatusWindowItemData[] GetItemDate()
    {
        return itemsList;
    }

    // アイテムの数取得関数
    public int GetItemTotal()
    {
        return itemsList.Length;
    }
}
