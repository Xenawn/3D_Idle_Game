using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI 
{
    //[SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpSlider;

    private void Start()
    {
        UpdateHPSlider(1); // �� ä�� ��
    }

    public void UpdateHPSlider(float percentage)
    {
        Debug.Log("Updating HP Slider with percentage: " + percentage);  // �α� �߰�
        hpSlider.value = percentage;
    }

  

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
