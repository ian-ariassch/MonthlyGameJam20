using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
