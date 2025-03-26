using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UIState
{
    Home,
    Game,
    GameOver,
}

public class UIManager : MonoBehaviour
{
    //HomeUI homeUI;
    
   public TextMeshProUGUI moneyText;
    GameUI gameUI;
    //GameOverUI gameOverUI;
    private UIState currentState;
    
    private static UIManager _uinstance;
    public static UIManager _Uinstance
    { get
        {
            return _uinstance;
        }
    } 
    private void Awake()
    {

        _uinstance = this;
 
        //homeUI = GetComponentInChildren<HomeUI>(true);
        //homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        //gameOverUI = GetComponentInChildren<GameOverUI>(true);
        //gameOverUI.Init(this);

        ChangeState(UIState.Game);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }

    public void SetGameOver()
    {
        ChangeState(UIState.GameOver);
    }

   
    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        Debug.Log("Updating HP Slider: " + currentHP + "/" + maxHP);
        gameUI.UpdateHPSlider(currentHP / maxHP);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
      //  homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
       // gameOverUI.SetActive(currentState);
    }
    // UI 업데이트 메소드
    public void UpdateMoneyDisplay(int money)
    {
        moneyText.text =  money.ToString();
    }
}