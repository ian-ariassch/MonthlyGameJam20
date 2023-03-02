using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LaserButton : MonoBehaviour
{
    FinalLasersController _finalLasersController;

    [SerializeField] private Sprite _pressedSprite; 

    [SerializeField] private Sprite _unpressedSprite;

    private SpriteRenderer _spriteRenderer;

    private Light2D _light2D;

    bool _isPressed = false;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

       _finalLasersController = GameObject.Find("FinalLasersController").GetComponent<FinalLasersController>();

        _spriteRenderer = GetComponent<SpriteRenderer>();

        _light2D = GetComponent<Light2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !_isPressed)
        {
            GetComponent<SpriteRenderer>().sprite = _pressedSprite;
            _light2D.intensity = 0;
            _isPressed = true;
            _audioSource.Play();
            _finalLasersController.buttonsPressed++;
        }
    }

    public void ResetButton()
    {
        _isPressed = false;
        _light2D.intensity = 1;
        GetComponent<SpriteRenderer>().sprite = _unpressedSprite;
    }
}
