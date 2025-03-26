using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName = "ScriptableObjects/PotionData")]
public class PotionData : ScriptableObject
{
    public string potionName;
    public float effectAmount;  // 회복량 또는 속도 증가량
    public float duration;      // 지속 시간 (가속 포션용)
}
