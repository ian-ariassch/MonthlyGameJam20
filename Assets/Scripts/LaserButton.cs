using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButton : MonoBehaviour
{
    FinalLasersController _finalLasersController;

    bool _isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
       _finalLasersController = GameObject.Find("FinalLasersController").GetComponent<FinalLasersController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !_isPressed)
        {
            _isPressed = true;
            _finalLasersController.buttonsPressed++;
        }
    }
}
