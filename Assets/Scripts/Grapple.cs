using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField] private Transform _ropePosition;
    [SerializeField] private LineRenderer _mainLineRenderer;
    [SerializeField] private DistanceJoint2D _distanceJoint2D;
    [SerializeField] private Transform[] _lineRendererPositions;

    public bool isRopeAttached = false;
    

     
    // Start is called before the first frame update
    void Start()
    {
        _distanceJoint2D.enabled = false;   
    }

    // Update is called once per frame
    void Update()
    {
        _mainLineRenderer.SetPosition(0, _distanceJoint2D.connectedAnchor);

        for(int i = 0; i < _lineRendererPositions.Length; i++)
        {
            _mainLineRenderer.SetPosition(i+1, _lineRendererPositions[i].position);
        }
    }

    public void AttachRope()
    {
        _distanceJoint2D.enabled = true;
        isRopeAttached = true;
    }

    public void DetachRope()
    {
        _distanceJoint2D.enabled = false;
        isRopeAttached = false;
    }
}
