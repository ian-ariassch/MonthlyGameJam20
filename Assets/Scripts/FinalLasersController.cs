using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLasersController : MonoBehaviour
{

    [SerializeField] int buttonsToPress = 2;
    public int buttonsPressed = 0;

    public Lasers[] lasers;

    private bool _areLasersActive = true;

    void Update()
    {
        if(buttonsPressed == buttonsToPress && _areLasersActive)
        {
            _areLasersActive = false;
            foreach(Lasers laser in lasers)
            {
                laser.TurnOffLaser();
            }
        }
    }

    public void ResetLasers()
    {
        foreach(Lasers laser in lasers)
        {
            laser.TurnOnLaser();
        }
        _areLasersActive = true;
        
        buttonsPressed = 0;
    }
}
