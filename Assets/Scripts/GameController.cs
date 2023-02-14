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

    [SerializeField] private GameObject _roof;

    [SerializeField] private Grapple _grapple;

    private bool _isGameOver = false;

    public bool gameHasStarted = false;

    void Update()
    {

        //if any key is pressed, start the game
        if (!gameHasStarted)
        {
            if (Input.anyKey)
            {
                _roof.SetActive(false);
                gameHasStarted = true;
            }
        }

        if (_timeToWin <= 0)
        {
            GameOver();
        }

        if(!_isGameOver && gameHasStarted)
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
        _timeToWin = 30f;
        _timerText.text = _timeToWin.ToString("F2");
        _isGameOver = false;
        _trophy.SetActive(true);
        _roof.SetActive(true);
        gameHasStarted = false;
        _player.transform.position = _startingPosition;
        _grapple.DetachRope();
        
    }
}
