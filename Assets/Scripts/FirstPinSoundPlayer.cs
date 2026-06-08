using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPinSoundPlayer : MonoBehaviour
{
    AudioSource audioPlayer;

    public void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        audioPlayer.Play();
    }

    
}
