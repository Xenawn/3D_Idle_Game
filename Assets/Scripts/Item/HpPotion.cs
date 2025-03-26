using UnityEngine;

public class HpPotion : PotionItem
{
    public override void UsePotion()
    {
        base.UsePotion();  // 부모 클래스의 UsePotion() 실행

        if (potionData != null)
        {
            GameManager.Instance.PlayerCondition.Health += potionData.effectAmount;
            Debug.Log($"체력 {potionData.effectAmount} 회복! 현재 체력: {GameManager.Instance.PlayerCondition.Health}");
        }
    }
}
