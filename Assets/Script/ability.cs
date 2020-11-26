using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ability : MonoBehaviour
{
    soul soul_Player;            // ソウルークラスの変数
   public GameObject soulmber;    // このスクリプトを持っている魂(オブジェクト)を入れる

    int count;
    bool countFlag;

    void Start()
    {
        soul_Player = soulmber.GetComponent<soul>();
        count = 0;
        countFlag = false;
    }
    void Update()
    {
        if (countFlag) { count++; }

        if (count >= 100) { count = 0; countFlag = false; soul_Player.SetSoulVel(0.08f); }

     //   Debug.Log(count);

    }


    // アビリティを取得関数
    public void Ability(int number)
    {
        countFlag = true;
        switch (number)
        {
            case 1:     // ナンバー１
                soul_Player.SetSoulVel(0.5f);       // 移動速度を速くする
                Debug.Log("speedUP");
                break;
        }
    }
}
