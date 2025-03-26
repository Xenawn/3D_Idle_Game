using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionItem : MonoBehaviour
{
    public PotionData potionData;  // ScriptableObject 데이터 참조

    public virtual void UsePotion()
    {
        if (potionData != null)
        {
            Debug.Log($"{potionData.potionName} 사용!");
        }
        else
        {
            Debug.LogWarning("PotionData가 설정되지 않았습니다!");
        }
    }
}
