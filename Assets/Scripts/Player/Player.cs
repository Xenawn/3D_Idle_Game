using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 3f;
    public int money = 0;
    // Update is called once per frame
    private void Awake()
    {
        GameManager.Instance.Player = this;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);    
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            GameManager.Instance.PlayerCondition.Health -= 10;
            UIManager._Uinstance.ChangePlayerHP(GameManager.Instance.PlayerCondition.Health, GameManager.Instance.PlayerCondition.MaxHealth);
            if (GameManager.Instance.PlayerCondition.Health <= 0)
            {
                Debug.Log("Die");
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        PotionItem potion = other.GetComponent<PotionItem>();
        if (potion != null)
        {
            GameManager.Instance.UsePotion(potion);
            Destroy(other.gameObject); // 포션 사용 후 제거
        }

        Money money = other.GetComponent<Money>();
        if (money != null)
        {
            money.EquipMoney(); // 돈 획득
            UpdateMoneyUI();  // UI 업데이트 메소드 호출
        }
    }
    public void UpdateMoneyUI()
    {
        UIManager._Uinstance.UpdateMoneyDisplay(money);  // UIManager에서 UI 업데이트 메소드 호출
    }
}
