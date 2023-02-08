using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLight : MonoBehaviour
{
    private bool shouldWait = false;

    [SerializeField] GameController _gameController;
    [SerializeField] float speed = 1f;
    [SerializeField] float waitTime = 2f;
    [SerializeField] bool goingRight = true;

    void Update()
    {
        if(shouldWait == false)
        {
            if (!goingRight)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _gameController.GameOver();
        }

        Debug.Log("HIT");

        if (other.gameObject.tag == "Wall")
        {
            goingRight = !goingRight;

            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        shouldWait = true;

        yield return new WaitForSeconds(waitTime);

        shouldWait = false;
    }
}
