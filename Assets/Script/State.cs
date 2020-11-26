using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

     public enum CONDITION
    {
        NORMAL,            // 通常
        POSSESSION,        // 憑依状態
        NOTPOSSESSION,        // 憑依状態解除
        ATTACK,             // 攻撃状態
        ABILITYLOOK,       // アビリティロック状態
        ITEMLOOK           // アイテムロック状態
    }

    // 状態遷移
    protected CONDITION state;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        state = CONDITION.NORMAL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SetCondition(CONDITION condition)
    {
        state = condition;
    }

}
