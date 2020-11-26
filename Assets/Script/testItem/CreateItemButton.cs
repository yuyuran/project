using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class CreateItemButton : MonoBehaviour
{
    // ナンバー
    private numbers numberStatus;
    public GameObject number;

    public int a;
    // アイテムデータベース
    private StatusWindowItemDataBase statusWindowItemDataBase;
    // アイテムボタンのプレハブ
    public GameObject itemPrefab;
    // アイテムを入れておくオブジェクト
    private GameObject[] item;


    void OnEnable()
    {
        numberStatus = number.GetComponent<numbers>();
        statusWindowItemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
        item = new GameObject[statusWindowItemDataBase.GetItemTotal()];

        // アイテムの総数分ボタン作成
        for(var i=0;i<a; i++)
        {
            item[i] = GameObject.Instantiate(itemPrefab) as GameObject;
            item[i].name = "Item" + i;
            // アイテムの親要素をこのスクリプトを持っているオブジェクトにする
            item[i].transform.SetParent(transform);
            // アイテムを持っているかどうか
            //if(numberStatus.GetItemFlag(i))
            //{
            //    Debug.Log(item[i].name);
            //    // アイテムデータベースの情報からスプライトを取得し、ボタンのスプライトに設定
            //    item[i].transform.GetComponent<Image>().sprite = statusWindowItemDataBase.GetItemDate()[i].GetItemSprite();
            //}
            //else
            //{
            //    // アイテムボタンのUI.Imageを不可視に。マウスやキーボードで操作不可
            //   // item[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            //   // item[i].transform.GetChild(0).GetComponent<Button>().interactable = false;
            }

            // ボタンに番号を設定
           // item[i].transform.GetChild(0).GetComponent<ItemButton>().SetItemNum(i);
        }
    }
    //void OnDisable()
    //{
    //    //　ゲームオブジェクトが非アクティブになる時に作成したアイテムボタンインスタンスを削除する
    //    for (var i = 0; i < statusWindowItemDataBase.GetItemTotal(); i++)
    //    {
    //        Destroy(item[i]);
    //    }
    //}

//