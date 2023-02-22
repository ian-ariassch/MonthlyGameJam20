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

    [SerializeField] GameObject _laserHitParticlesPrefab;

    [SerializeField] Transform _laserOutPoint;

    private GameObject _laserHitParticles;

    public LineRenderer _lineRenderer;

    Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();

        _direction = _facingRight ? transform.right : -transform.right;

        _laserHitParticles = Instantiate(_laserHitParticlesPrefab, transform.position, Quaternion.identity);

        _laserHitParticles.transform.right = -_direction;

        _lineRenderer = GetComponent<LineRenderer>();

        _lineRenderer.useWorldSpace = true;

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

        hit = Physics2D.Raycast(_laserOutPoint.position, _direction);

        _lineRenderer.SetPosition(0, _laserOutPoint.position);

        if (hit)
        {
            _laserHitParticles.transform.position = hit.point - _direction * 0.05f;

            _lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.gameObject.tag == "Player")
            {
                _gameController.GameOver();
            }
        }
    }

    public void TurnOffLaser()
    {
        StopCoroutine("StartLaserSequence");
        StopCoroutine("ToggleLaser");
        _lineRenderer.enabled = false;
        _laserHitParticles.SetActive(false);
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
            _laserHitParticles.SetActive(_lineRenderer.enabled);
            yield return new WaitForSeconds(intervalTime);
        }
    }
    


}
