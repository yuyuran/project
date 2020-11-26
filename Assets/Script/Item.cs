using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "number" || other.gameObject.tag == "numberAttack")
        {
            // 数字に当たると消える
            Destroy(gameObject);
        }
    }
}
