using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] private Transform _ropePosition;
    [SerializeField] private LineRenderer _mainLineRenderer;
    [SerializeField] private LineRenderer _backLineRenderer;
    [SerializeField] private DistanceJoint2D _distanceJoint2D;

    [SerializeField] private Transform[] _backLineRendererPositions;

     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mainLineRenderer.SetPosition(0, _distanceJoint2D.connectedAnchor);

        for(int i = 0; i < _backLineRendererPositions.Length; i++)
        {
            _mainLineRenderer.SetPosition(i+1, _backLineRendererPositions[i].position);
        }
    }
}
