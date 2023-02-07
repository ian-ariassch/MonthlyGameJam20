using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _timeToWin = 30f;

    [SerializeField] private TextMeshProUGUI _timerText;

    private bool _isGameOver = false;

    void Update()
    {
        if (_timeToWin <= 0)
        {
            GameOver();
        }

        if(!_isGameOver)
        {
            _timeToWin -= Time.deltaTime;
            _timerText.text = _timeToWin.ToString("F2");
        }
    }

    public void Win()
    {
        Debug.Log("You Win!");
        _isGameOver = true;
    }

    public void GameOver()
    {
        Debug.Log("You Lose!");
        _isGameOver = true;
    }
}
