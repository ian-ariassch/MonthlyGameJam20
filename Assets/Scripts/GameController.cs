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

    [SerializeField] private BoxCollider2D _roofCollider;

    [SerializeField] private Grapple _grapple;

    [SerializeField] private SpriteRenderer _glassRoof;

    [SerializeField] private Sprite _glassRoofBroken;

    [SerializeField] private Sprite _glassRoofFixed;

    [SerializeField] private GameObject[] _uiOptions;

    [SerializeField] private GameObject _nextLevelUiButton;

    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private AudioSource _audioSourceSiren;

    [SerializeField] private AudioSource _audioSourceGlassShatter; 

    [SerializeField] private FinalLasersController _finalLasersController;

    [SerializeField] private LaserButton[] _laserButtons;

    [SerializeField] private Lasers[] _lasers;

    public bool _isGameOver = false;

    private bool _gameWon = false;

    public bool gameHasStarted = false;
    void Update()
    {
        if (!gameHasStarted)
        {
            if (Input.anyKey)
            {
                _roofCollider.enabled = false;
                _glassRoof.sprite = _glassRoofBroken;
                _particleSystem.Play();
                _audioSourceGlassShatter.Play();
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
        _gameWon = true;
        _isGameOver = true;
        TurnOnUIOptions();
    }

    public void GameOver()
    {

        if(!_isGameOver)
            _audioSourceSiren.Play();

        if(developerMode){
            Debug.Log("You Lose!");
        }
        else{
            TurnOnUIOptions();
            _isGameOver = true;
        }




    }

    public void RestartGame()
    {
        _player.transform.position = _startingPosition;
        _timeToWin = 30f;
        _timerText.text = _timeToWin.ToString("F2");
        _trophy.SetActive(true);
        _roofCollider.enabled = true;
        gameHasStarted = false;
        _grapple.DetachRope();
        _glassRoof.sprite = _glassRoofFixed;
        TurnOffUIOptions();
        _gameWon = false;
        _isGameOver = false;

        foreach(LaserButton laserButton in _laserButtons)
        {
            laserButton.ResetButton();
        }

        foreach(Lasers laser in _lasers)
        {
            laser.TurnOnLaser();
        }

        _finalLasersController.ResetLasers();
    }

    void TurnOnUIOptions()
    {
        foreach (GameObject uiOption in _uiOptions)
        {
            uiOption.SetActive(true);
        }

        if(_gameWon && _nextLevelUiButton)
        {
            _nextLevelUiButton.SetActive(true);
        }
    }

    void TurnOffUIOptions()
    {
        foreach (GameObject uiOption in _uiOptions)
        {
            uiOption.SetActive(false);
        }

        if(_nextLevelUiButton)
            _nextLevelUiButton.SetActive(false);
    }
}
