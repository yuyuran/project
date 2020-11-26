using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemeManager : MonoBehaviour
{
    numbers number;

    // Start is called before the first frame update
    void Start()
    {
        number = GetComponent<numbers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // アイテムの効果
    public void Itemefficacy(string ItemName)
    {
        if(ItemName=="Attack")
        {
            number.SetAttack(200);
        }
    }



}
