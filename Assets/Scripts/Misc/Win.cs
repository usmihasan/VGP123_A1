using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Win : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;
    AudioSource winAudioSource;

    public AudioMixerGroup soundFXMixer;
    public AudioClip winSFX;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
