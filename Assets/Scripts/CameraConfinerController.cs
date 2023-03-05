using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfinerController : MonoBehaviour
{
    private PolygonCollider2D _cameraConfiner;

    [SerializeField] private Transform _confinerYPosition;
    // Start is called before the first frame update
    void Start()
    {
        _cameraConfiner = GetComponent<PolygonCollider2D>();

        //set camera confiner bottom vertices to the confinerYPosition

        Vector2[] vertices = _cameraConfiner.points;

        for (int i = 2; i < vertices.Length; i++)
        {
            vertices[i] = new Vector2(vertices[i].x, _confinerYPosition.position.y);
        }

        _cameraConfiner.points = vertices;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
