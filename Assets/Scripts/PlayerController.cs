using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRb;

    private Animator _playerAnimator;

    [SerializeField] private float _pushForce = 10f;

    [SerializeField] private float verticalSpeed = 10f;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();

        _playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        handleMovement();
        handleAnimation();
    }

    void handleMovement() {
        Vector2 velocity = _playerRb.velocity;

        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)) {
            velocity += Vector2.left * _pushForce * Time.deltaTime;

            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.D)) {
            velocity += Vector2.right * _pushForce * Time.deltaTime;

            transform.localScale = new Vector3(1, 1, 1);
        }

        _playerRb.velocity = velocity;
    }

    void handleAnimation() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
            _playerAnimator.SetBool("isClimbing", true);
        } else {
            _playerAnimator.SetBool("isClimbing", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Wall") {
            _playerAnimator.SetBool("isTouchingWall", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Wall") {
            _playerAnimator.SetBool("isTouchingWall", false);
        }
    }

}
