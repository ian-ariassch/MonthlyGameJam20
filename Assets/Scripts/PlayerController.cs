using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRb;

    //serializable field called pushForce
    [SerializeField] private float _pushForce = 10f;
    
    private Vector2 _lastVelocity;

    private bool _hasBounced = false;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
    }

    void handleMovement() {
        Vector2 velocity = _playerRb.velocity;

        if (Input.GetKey(KeyCode.W)) {
            velocity += Vector2.up * _pushForce;
        }
        if (Input.GetKey(KeyCode.S)) {
            velocity += Vector2.down * _pushForce;
        }
        if (Input.GetKey(KeyCode.A)) {
            velocity += Vector2.left * _pushForce;
        }
        if (Input.GetKey(KeyCode.D)) {
            velocity += Vector2.right * _pushForce;
        }

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            _hasBounced = false;

        _playerRb.velocity = velocity;
    }
}
