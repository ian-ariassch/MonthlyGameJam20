using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _playerRb;

    private Animator _playerAnimator;

    [SerializeField] private float _pushForce = 10f;

    [SerializeField] private float verticalSpeed = 10f;

    [SerializeField] private GameController _gameController;

    [SerializeField] private Grapple _grappleController;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();

        _playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(_gameController.gameHasStarted && _grappleController.isRopeAttached && !_gameController._isGameOver){
            handleMovement();
            handleAnimation();
        }
    }

    void handleMovement() {
        Vector2 velocity = _playerRb.velocity;

        if (Input.GetKey(KeyCode.W) && transform.position.y < 3f) {
            transform.Translate(Vector2.up * verticalSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector2.down * verticalSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)) {
            velocity += Vector2.left * _pushForce * Time.deltaTime;

            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKey(KeyCode.D)) {
            velocity += Vector2.right * _pushForce * Time.deltaTime;

            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y, transform.localScale.z);
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
        if (collision.gameObject.tag == "Wall") {
            _playerAnimator.SetBool("isTouchingWall", true);
        }

        if (collision.gameObject.tag == "Goal") {
            _gameController.Win();
            collision.gameObject.SetActive(false);
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Wall") {
            _playerAnimator.SetBool("isTouchingWall", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Danger") {
            _gameController.GameOver();
        }

        if (collision.gameObject.tag == "AttachRope"){
            _grappleController.AttachRope();
        }
    }

}
