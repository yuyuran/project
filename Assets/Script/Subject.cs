using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    // 倒したときのエフェクト
    public GameObject breakEffect;
    //当たり判定
    private void OnTriggerEnter(Collider collision)
    {
        //衝突したオブジェクトが"判定のしたい物"だったとき
        if (collision.gameObject.CompareTag("number")|| collision.gameObject.CompareTag("numberAttack"))
        {
            // エフェクトを発生
            GenerateEffect();
            //スクリプトがアタッチされているオブジェクト自身(Subject)を削除
            Destroy(gameObject);

        }
    }

    // エフェクトの生成
    void GenerateEffect()
    {
        // エフェクト生成
        GameObject effect = Instantiate(breakEffect) as GameObject;
        // エフェクトの発生地点の設定
        effect.transform.position = gameObject.transform.position;
    }
}
