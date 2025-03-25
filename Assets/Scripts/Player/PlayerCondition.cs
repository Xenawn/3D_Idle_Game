using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    [Range(1, 100)][SerializeField] private float health = 10;
    public float Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0, 100);
    }

    [Range(1f, 20f)][SerializeField] private float speed = 3;
    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0, 20);
    }


    [Range(1f, 20f)][SerializeField] private float attack = 10;
    public float Attack
    {
        get => attack;
        set => attack = Mathf.Clamp(value, 0, 20);
    }

    public float MaxHealth = 100f;
    private void Awake()
    {
        GameManager.Instance.PlayerCondition = this;
        Health = MaxHealth;
        
    }
}
