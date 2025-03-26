using UnityEngine;

[CreateAssetMenu(fileName = "NewPotion", menuName = "ScriptableObjects/PotionData")]
public class PotionData : ScriptableObject
{
    public string potionName;
    public float effectAmount;  // ȸ���� �Ǵ� �ӵ� ������
    public float duration;      // ���� �ð� (���� ���ǿ�)
}
