using UnityEngine;
using System.Collections;

public class SpeedPotion : PotionItem
{
    public override void UsePotion()
    {
        base.UsePotion();  // �θ� Ŭ������ UsePotion() ����

        if (potionData != null)
        {
            PlayerCondition player = GameManager.Instance.PlayerCondition;
            StartCoroutine(SpeedBoost(player, potionData.effectAmount, potionData.duration));
        }
    }

    private IEnumerator SpeedBoost(PlayerCondition player, float amount, float duration)
    {
        player.Speed += amount;
        Debug.Log($"�ӵ� {amount} ����! ���� �ӵ�: {player.Speed}");
        yield return new WaitForSeconds(duration);
        player.Speed -= amount;
        Debug.Log($"�ӵ� ���� ȿ�� ����! ���� �ӵ�: {player.Speed}");
    }
}
