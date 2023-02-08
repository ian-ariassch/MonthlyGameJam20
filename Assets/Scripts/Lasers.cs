using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    [SerializeField] GameController _gameController;

    [SerializeField] bool _facingRight = true;

    [SerializeField] float upTime = 0.5f;
    [SerializeField] float downTime = 0.5f;

    [SerializeField] float delayToStart = 0.5f;

    LineRenderer _lineRenderer;

    Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _direction = _facingRight ? transform.right : -transform.right;

        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.enabled = false;

        StartCoroutine("StartLaserSequence");
    }

    void Update()
    {
        if(_lineRenderer.enabled)
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, _direction);

        _lineRenderer.SetPosition(0, transform.position);

        if (hit)
        {
            _lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.gameObject.tag == "Player")
            {
                _gameController.GameOver();
            }
        }
    }

    private IEnumerator StartLaserSequence()
    {
        yield return new WaitForSeconds(delayToStart);
        StartCoroutine("ToggleLaser");
    }

    private IEnumerator ToggleLaser()
    {
        while (true)
        {
            float intervalTime = _lineRenderer.enabled ? downTime : upTime;
            _lineRenderer.enabled = !_lineRenderer.enabled;
            yield return new WaitForSeconds(intervalTime);
        }
    }
    


}
