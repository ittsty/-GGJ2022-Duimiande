using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomaneger : MonoBehaviour
{
    public AudioClip[] SFX;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject audioSource2;
    [SerializeField] GameObject audioSource3;
    public static Audiomaneger instance;

    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void audioBlock()
    {
        audioSource.PlayOneShot(SFX[0]);
    }
    public void audioDuality()
    {
        audioSource.PlayOneShot(SFX[1]);
    }
    public void audioFall()
    {
        audioSource.PlayOneShot(SFX[2]);
    }
    public void audioLose()
    {
        audioSource2.SetActive(false);
        audioSource3.SetActive(false);
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(SFX[3]);
    }
    public void audiolostHP()
    {
        audioSource.PlayOneShot(SFX[4]);
    }
   public void audioWin()
    {
        audioSource2.SetActive(false);
        audioSource3.SetActive(false);
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(SFX[5]);
    }
}
