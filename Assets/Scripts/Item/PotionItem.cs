using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionItem : MonoBehaviour
{
    public PotionData potionData;  // ScriptableObject ������ ����

    public virtual void UsePotion()
    {
        if (potionData != null)
        {
            Debug.Log($"{potionData.potionName} ���!");
        }
        else
        {
            Debug.LogWarning("PotionData�� �������� �ʾҽ��ϴ�!");
        }
    }
}
