using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISettings : MonoBehaviour
{
    [Header("SliderPanel")]
    [SerializeField] private Slider player1SpeedSlider;
    [SerializeField] private Slider player2SpeedSlider;
    [Header("UIText")]
    [SerializeField] private TextMeshProUGUI player1SpeedText;
    [SerializeField] private TextMeshProUGUI player2SpeedText;
    [Header("PlayerMovement")]
    [SerializeField] private Movement player1movement;
    [SerializeField] private Movement player2movement;


    private void Awake()
    {
        player1SpeedSlider.onValueChanged.AddListener(SetPlayer1Speed);
        player2SpeedSlider.onValueChanged.AddListener(SetPlayer2Speed);
 
        
    }

    private void OnDestroy()
    {

        player1SpeedSlider.onValueChanged.RemoveListener(SetPlayer1Speed);
        player2SpeedSlider.onValueChanged.RemoveListener(SetPlayer2Speed);


    }

    public void SetPlayer1Speed(float speed)
    {
        player1movement.SetMovementSpeed(speed);
        player1SpeedText.text = speed.ToString("F2");
    }

    public void SetPlayer2Speed(float speed)
    {
        player2movement.SetMovementSpeed(speed);
        player2SpeedText.text = speed.ToString("F2");
    }
}

