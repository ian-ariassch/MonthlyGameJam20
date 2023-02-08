using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _timeToWin = 30f;

    [SerializeField] private TextMeshProUGUI _timerText;

    [SerializeField] private GameObject _trophy;

    [SerializeField] private GameObject _player;

    [SerializeField] private Vector3 _startingPosition;

    [SerializeField] private bool developerMode = false;

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
        if(developerMode){
            Debug.Log("You Lose!");
            _isGameOver = true;
        }
        else{
            RestartGame();
        }
    }

    public void RestartGame()
    {
        _isGameOver = false;
        _timeToWin = 30f;
        _trophy.SetActive(true);
        _player.transform.position = _startingPosition;
        
    }
}
