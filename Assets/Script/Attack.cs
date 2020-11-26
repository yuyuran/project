using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    private int attack;
    // Start is called before the first frame update
    void Start()
    {
        attack = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetAttack() { return attack; }
}
