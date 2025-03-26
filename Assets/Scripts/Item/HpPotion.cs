using UnityEngine;

public class HpPotion : PotionItem
{
    public override void UsePotion()
    {
        base.UsePotion();  // �θ� Ŭ������ UsePotion() ����

        if (potionData != null)
        {
            GameManager.Instance.PlayerCondition.Health += potionData.effectAmount;
            Debug.Log($"ü�� {potionData.effectAmount} ȸ��! ���� ü��: {GameManager.Instance.PlayerCondition.Health}");
        }
    }
}
