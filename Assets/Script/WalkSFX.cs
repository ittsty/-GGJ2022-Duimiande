using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSFX : MonoBehaviour
{
    public static WalkSFX instance;
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void walk_sfx()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.volume = UnityEngine.Random.Range(0.75f, 0.8f);
            audioSource.pitch = UnityEngine.Random.Range(0.75f, 0.8f);
            audioSource.Play();
        }
    }
}
