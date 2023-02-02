using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private LineRenderer _lineRenderer;

     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(1, _playerPosition.position);
        _lineRenderer.SetPosition(0, _playerPosition.position + new Vector3(0, 10, 0));
    }
}
