using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soul : State
{
    // ジョイコンの変数
    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;


    // 状態遷移
    //public enum CONDITION
    //{
    //    NORMAL,            // 通常
    //    IDKING,             // アイドリング
    //    STOP,               // 停止
    //    POSSESSION,        // 憑依状態
    //}


    // 状態変数
  //  CONDITION condition;
 //   bool soulConditionFlag;

    // 数字格納変数
    GameObject number;

    // HPバー
    public Slider hpber;
    // 
    public Text text;

    int soulHP;                 // 魂の体力
    float soulVel;              // 魂の速さ
 // GameObject[] soulitem;        // アイテム



    // Start is called before the first frame update
    protected override void Start()
    {

        base.Start();

        // ジョイコンの値を取得させるための準備
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        m_joyconL = m_joycons.Find(c => c.isLeft);
        m_joyconR = m_joycons.Find(c => !c.isLeft);

        // 魂のステータス
        soulHP = 1000;
        soulVel = 0.00f;
  
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(base.state);

        // 進行方向をカメラと同期させる
     //   gameObject.transform.rotation = Soulcamera.transform.rotation;

        //  回転を制限
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.Clamp(gameObject.transform.position.y, 0, 0), gameObject.transform.position.z);

        // HPを更新
        hpber.value = soulHP;

        // 前進(joyconR-ZR)
        if (m_joyconR.GetButtonDown(Joycon.Button.SHOULDER_2)) {  soulVel = 0.08f; text.text = "前進！";}
        if (m_joyconR.GetButtonUp(Joycon.Button.SHOULDER_2)) {  soulVel = 0.00f; text.text = "停止中"; }

        // 憑依状態でYを押すと憑依解除
        if (base.state == CONDITION.POSSESSION && m_joyconR.GetButton(Joycon.Button.DPAD_LEFT))
        {
            //number.transform.parent = null;
            // soulConditionFlag = false;
            base.state = CONDITION.NORMAL;
            number.GetComponent<numbers>().SetCondition(CONDITION.NOTPOSSESSION);
        }

        gameObject.transform.localRotation = new Quaternion(0, -m_joyconL.GetVector().z, 0, m_joyconL.GetVector().w);

        gameObject.transform.Translate(0, 0, soulVel);
    }

    void OnTriggerEnter(Collider other)
    {
        // SoulHitBox(tag=number)に当たった時
        if (other.gameObject.tag == "number")
        {
            // SoulHitBoxオブジェクトの一番上の親のスクリプトを取得
            numbers numberObj = other.gameObject.transform.GetComponent<numbers>();
            // 当たったナンバーが憑依されてないない ＆ 魂も憑依していないなら
            if (/*!numberObj.GetCondition()&&*/ base.state==CONDITION.NORMAL)
            {
                // 憑依状態にする
                ///   soulConditionFlag = true;
                base.state = CONDITION.POSSESSION;

                // ナンバーの状態を憑依状態に
                numberObj.SetCondition(CONDITION.POSSESSION);

                // 取得した数字を保存
                number = other.gameObject;

                Debug.Log("憑依！");
                // ナンバーの回転角と一緒にする
                gameObject.transform.rotation = other.transform.rotation;

                // 当たった数字を子にする
                numberObj.transform.parent = gameObject.transform;


                // 憑依した時にカメラの位置を数字に適応させる(-1)
                Vector3 pos = new Vector3(other.transform.localPosition.x, other.transform.localPosition.y + 1.5f, other.transform.localPosition.z - 4);

            }
        }
    }


    // 速度取得関数
    public void SetSoulVel(float vel){ soulVel = vel; Debug.Log(soulVel); }


    // HP計算関数
    public void HPCalculation(int attack)
    {
        soulHP = soulHP - attack;
        Debug.Log("HP計算");
    }

}
