using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class numbers : State
{

    bool itemLock;
    bool abilityLock;

    public int number;      // ナンバー
    private Animator animator;  // アニメーター

    public Text text;


    // ボタン格納変数
    public GameObject[] button;
    // ボタンの中のplane格納変数
    private GameObject selectObj;

    // 魂取得変数
    soul soulObj;

    // ボタンの画像変数
    Sprite buttonSprite;
    // アイテムカウント
    int itemCount = 0;
    int buttonNumber = 0;

    // アビリティ変数
    ability ability;

    ItemeManager itemeManager;
    public GameObject itemeManagerObj;

    public float vel;         // 速さ
    private int attack;      // 攻撃力
    public int UIattack;      // 表示用攻撃力

    //   private Vector3 camerarote;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        soulObj = null;


        itemLock = false;
        abilityLock = false;
        base.state = CONDITION.NORMAL;

        ability = GetComponent<ability>();
        itemeManager = itemeManagerObj.GetComponent<ItemeManager>();
       // attacObj = attackScript.GetComponent<Attack>();
        buttonSprite = button[itemCount].GetComponent<Image>().sprite;

        // 攻撃力初期値
        attack = 0;
        UIattack = 100;

        animator = GetComponent<Animator>();


        // 数字の分だけアイテム枠を表示
        for (int i = 0; i < number; i++){ button[i].SetActive(true);}

        // 最初に選択枠表示させるパネルを入れる
        selectObj = button[0].GetComponent<Button>().transform.Find("Panel").gameObject;
        // 選択枠(パネル)の色(赤)を設定
        selectObj.GetComponent<Image>().color = new Color32(231, 77, 77, 100);
    }

    // Update is called once per frame
    void Update()
    {
        // 状態を更新
        NumberCondition(base.state);

        // 憑依状態ならアビリティやアイテム使用可能
        if (base.state==CONDITION.POSSESSION) { NumberCondition(base.state); Behavior(); }


        // 攻撃状態へ
        if (Input.GetKey(KeyCode.X) && base.state == CONDITION.POSSESSION)
        {
            // 攻撃力を反映
            attack = UIattack;
            animator.SetTrigger("Attack" + number);

        }


    }


    void OnCollisionEnter(Collision other)
    {

    }


    void OnTriggerEnter(Collider other)
    {

        // アイテムに当たったらボタンの画像を当たったアイテムと同じにする
        if (other.gameObject.tag == "item")
        {
            // アイテム所持数が数字と同じ数になったら抜ける
            if (itemCount == number) { return; }

            button[itemCount].GetComponent<Image>().sprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
            Debug.Log(button[itemCount].GetComponent<Image>().sprite.name);
            itemCount++;
        }

        // 魂との当たり判定
        if (other.gameObject.tag == "soul")
        {
            // 憑依UI表示

            // ソウルを取得
            soulObj = other.gameObject.GetComponent<soul>();
        }

        // 他のナンバーとの当たり判定
        if (other.gameObject.tag == "numberAttack"&& base.state == CONDITION.POSSESSION)
        {
            Attack attack = other.GetComponent<Attack>();

            // ダメージ計算
            soulObj.HPCalculation(attack.GetAttack());
        }
   
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "itemLock")
        {
            base.state =CONDITION.ITEMLOOK;
        }

        if (other.gameObject.tag == "abilityLock")
        {
            base.state = CONDITION.ABILITYLOOK;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "itemLock")
        {
            base.state = CONDITION.NORMAL;
        }

        if (other.gameObject.tag == "abilityLock")
        {
            base.state = CONDITION.NORMAL;
            abilityLock = false;

        }
    }


    void NumberCondition(CONDITION state)
    {
        switch (state)
        {
            case CONDITION.NORMAL:
                itemLock = false;
                break;
            case CONDITION.ATTACK:
                break;

            case CONDITION.ABILITYLOOK:
                abilityLock = true;
                text.text = "アビリティが使えない";
                break;
                // アイテムロック
            case CONDITION.ITEMLOOK:
                itemLock = true;
                text.text = "アイテムが使えない";
                break;
                // 憑依状態解除
            case CONDITION.NOTPOSSESSION:
                Destroy(gameObject);
                break;

        }
    }


    void Behavior()
    {
        // アビリティ仕様
        if (!abilityLock&&Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button3) || Input.GetKey(KeyCode.Joystick2Button3))
        {
            // ナンバーを渡してアビリティを取得
            ability.Ability(number);
        }

        // アイテム選択(数字が1の時は機能しない)
        if (Input.GetKeyUp(KeyCode.R)&&number>1)
        {
            if (buttonNumber == number) { buttonNumber = 0; }
            selectObj.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
            buttonNumber++;
            selectObj = button[buttonNumber].GetComponent<Button>().transform.Find("Panel").gameObject;
            selectObj.GetComponent<Image>().color = new Color32(231, 77, 77, 100);
        }

        // アイテム使用
        if (Input.GetKeyUp(KeyCode.A)|| Input.GetKey(KeyCode.Joystick1Button0) && !itemLock)
        {
            itemeManager.Itemefficacy(button[buttonNumber].GetComponent<Image>().sprite.name);
            button[buttonNumber].GetComponent<Image>().sprite = buttonSprite;

            Debug.Log(attack);

        }

    }


    // 速度設定関数
    public void GetVel(float numberVel) { vel = numberVel; }

    // 攻撃力取得関数
    public void SetAttack(int numberAttack) { attack += numberAttack; }


    // 憑依関係
    public override void SetCondition(CONDITION condition) { base.state = condition; }


    // 速度を返す
    public float SetVel(){ return vel; }

}
