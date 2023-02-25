using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AudioDistance : MonoBehaviour
{
    public Transform listenerTransform;
    public AudioSource audioSource;
    public float minDist=1;
    public float maxDist=400;

    public float maxVolume = 0.6f;
 
    void Update()
    {
        float dist = Vector3.Distance(transform.position, listenerTransform.position);

        Debug.Log("Distance: " + dist);
 
        if(dist < minDist)
        {
            audioSource.volume = maxVolume;
        }
        else if(dist > maxDist)
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = maxVolume - ((dist - minDist) / (maxDist - minDist));
        }
    }
}