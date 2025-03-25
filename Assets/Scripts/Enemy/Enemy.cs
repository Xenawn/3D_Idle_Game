using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    public float maxHp = 100;

   
    internal void TakeDamage(object attackDamage)
    {
       hp-=GameManager.Instance.PlayerCondition.Attack;

        if(hp<=0)
        {
            hp = 0;
            Debug.Log("Àû »ç¸Á ");
        }
    }

    private void Start()
    {
        hp = maxHp;
    }


}
