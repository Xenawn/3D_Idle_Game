using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Money : MonoBehaviour
{
    public MoneyData moneyData;

    public void EquipMoney()
    {
        Debug.Log($" {moneyData.price} G 획득 시도!");
        GameManager.Instance.Player.money += moneyData.price;
        Debug.Log($" 현재 돈: {GameManager.Instance.Player.money}");
      //  Destroy(gameObject);
    }
}
