using UnityEngine;
using System.Collections;

public class SpeedPotion : PotionItem
{
    public override void UsePotion()
    {
        base.UsePotion();  // 부모 클래스의 UsePotion() 실행

        if (potionData != null)
        {
            PlayerCondition player = GameManager.Instance.PlayerCondition;
            StartCoroutine(SpeedBoost(player, potionData.effectAmount, potionData.duration));
        }
    }

    private IEnumerator SpeedBoost(PlayerCondition player, float amount, float duration)
    {
        player.Speed += amount;
        Debug.Log($"속도 {amount} 증가! 현재 속도: {player.Speed}");
        yield return new WaitForSeconds(duration);
        player.Speed -= amount;
        Debug.Log($"속도 증가 효과 종료! 현재 속도: {player.Speed}");
    }
}
