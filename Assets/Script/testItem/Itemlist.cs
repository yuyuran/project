using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemlist : MonoBehaviour
{

    // シングルトン
    private static Itemlist itemList = new Itemlist();

    // アイテムボタンのオブジェクトのリスト
    public List<GameObject> btnList = new List<GameObject>();
    // 選択状態のアイテムの番号を保存
    public int selectedItemID = -1;
    // 選択されている状態を示すキーワード
    public string selectedSymbol = "Selected";
    // 割り当てなし状態の画像名
    public string emptySybol = "UiSprite";

    private Sprite itemSprite;


    void Start()
    {
        // 1恩在するボタンをリストへ
        int i = 0;
        while (GameObject.Find("Button(" + i.ToString() + ")") != null)
        {
            btnList.Add(GameObject.Find("Button(" + i.ToString() + ")"));
            i++;

            Debug.Log("Button(" + i.ToString());
        }
        itemSprite = GetComponent<Sprite>();

        itemSprite = Resources.Load<Sprite>("Attack");
    }

    //    private Itemlist()
    //{
    //    // 1恩在するボタンをリストへ
    //    int i = 0;
    //    while(GameObject.Find("Button("+i.ToString()+")")!=null)
    //    {

    //        btnList.Add(GameObject.Find("Button(" + i.ToString() + ")"));
    //        i++;

    //        Debug.Log("Button(" + i.ToString());
    //    }
    //}

    // アイテムリスト取得関数
    public static Itemlist getInstance()
    {
        return itemList;
    }

    // アイテムリストに追加する
    public void add(string itemName)
    {
        for(int i=0;i<btnList.Count;i++)
        {// 画像の名前取得
            string item_name = btnList[i].GetComponent<Image>().sprite.name;
            if(itemName == itemSprite.name)
            {
                btnList[i].GetComponent<Image>().sprite = itemSprite;
                break;
            }
        }
    }

    // 選択されているアイテムを消去
    public void removeSelectedItem()
    {
        // 選択されていないなら何もしない
        if (selectedItemID == -1) { return; }

        // 一番最後のボタンなら最後だけ変える
        else if (selectedItemID == btnList.Count - 1)
        {
            btnList[selectedItemID].GetComponent<Image>().sprite = Resources.Load(emptySybol, typeof(Sprite)) as Sprite;
            selectedItemID = -1;
        }
        else
        {
            // 途中だけ取りのぞく時
            // num番目のボタンから順番に、次のボタンの画像を割り当てる
            for (int i = selectedItemID; i < btnList.Count - 1; i++)
            {
                btnList[i].GetComponent<Image>().sprite = btnList[i + 1].GetComponent<Image>().sprite;
                selectedItemID = -1;
            }
        }
    }

        public void click(GameObject btnObject)
        {

            string im_name = btnObject.GetComponent<Image>().sprite.name;
            // 選択されたボタンの番号を取得
            int id = int.Parse(btnObject.name.Substring("Button (".Length, btnObject.name.Length - "Button ()".Length));

            // 既に選択状態なら選択状態を解除する
            if (id == selectedItemID)
            {

                im_name = im_name.Substring(selectedSymbol.Length);
                btnObject.GetComponent<Image>().sprite = Resources.Load(im_name, typeof(Sprite)) as Sprite;
                selectedItemID = -1;

            }
            else if (im_name != emptySybol)
            {   // 何かのアイテムが割り当てられていたら

                // 他に選択状態のアイテムがあるなら非選択状態に変更
                if (selectedItemID != -1)
                {
                    string temp = btnList[selectedItemID].GetComponent<Image>().sprite.name.Substring(selectedSymbol.Length);
                    btnList[selectedItemID].GetComponent<Image>().sprite = Resources.Load(temp, typeof(Sprite)) as Sprite;
                    selectedItemID = -1;
                }

                // 選択状態にする
                btnObject.GetComponent<Image>().sprite = Resources.Load("Image/" + selectedSymbol + im_name, typeof(Sprite)) as Sprite;
                selectedItemID = id;
            }

        }
}
