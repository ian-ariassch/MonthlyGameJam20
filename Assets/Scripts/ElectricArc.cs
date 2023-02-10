using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricArc : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    [SerializeField] private Transform _endPoint;

    [SerializeField] private float _speed = 1f;

    [SerializeField] private float _startingTime = 0f;

    private float _actualSpeed = 0f;

    private Vector2 _localStartPoint;

    private Vector2 _localEndPoint;

    protected float _time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _actualSpeed = 10f - _speed;

        _time = _startingTime;

        _localStartPoint = new Vector2(_startPoint.position.x, _startPoint.position.y);

        _localEndPoint = new Vector2(_endPoint.position.x, _endPoint.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        // _time %= _actualSpeed;

        // Debug.Log(_time);
        Debug.Log("Actual Speed: " + _actualSpeed);
        if(_time < _actualSpeed)
        transform.position = MathParabola.Parabola(_localStartPoint, _localEndPoint, 2f, _time / _actualSpeed);
        else
        {
            Debug.Log("Swapping");
            Vector2 temp = _localStartPoint;
            _localStartPoint = _localEndPoint;
            _localEndPoint = temp;
            _time = 0f;
        }
    }
}
