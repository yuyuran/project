using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{

  //  private Text informationText;
    private StatusWindowItemDataBase itemDataBase;
    private int itemNum;

    // Start is called before the first frame update
    void Start()
    {
        itemDataBase = Camera.main.GetComponent<StatusWindowItemDataBase>();
     //   informationText = transform.parent.parent.parent.Find("Information/Text").GetComponent<Text>();
    }

    //// アイテムボタンが選択されたら情報を表示
    //public void OnSelected()
    //{
    //    informationText.text = itemDataBase.GetItemDate()[itemNum].GetItemInformation();
    //}
    //// アイテムボタンから離れたら情報を消去
    //public void OnDeselected()
    //{
    //    informationText.text = "";
    //}

    // アイテムの番号をセット
    public void SetItemNum(int number)
    {
        itemNum = number;
    }

    // アイテムの番号取得
    public int GetItemNum()
    {
        return itemNum;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
