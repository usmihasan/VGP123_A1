using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerFire : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;
    AudioSource fireAudioSource;

    public AudioMixerGroup soundFXMixer;
    public AudioClip fireSFX;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public float projectileSpeed;
    public Projectile projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (projectileSpeed <= 0)
            projectileSpeed = 12.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Unity inspector values not set");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetBool("isFiring", true);
            }
        }
    }

    void FireProjectile()
    {
        if (sr.flipX)
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointLeft.position, spawnPointLeft.rotation);
            projectileInstance.speed = -projectileSpeed;
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectilePrefab, spawnPointRight.position, spawnPointRight.rotation);
            projectileInstance.speed = projectileSpeed;
        }

        if (!fireAudioSource)
        {
            fireAudioSource = gameObject.AddComponent<AudioSource>();
            fireAudioSource.outputAudioMixerGroup = soundFXMixer;
            fireAudioSource.clip = fireSFX;
            fireAudioSource.loop = false;
        }

        fireAudioSource.Play();

    }

    void ResetFireAnimation()
    {
        anim.SetBool("isFiring", false);
        FireProjectile();
    }
}
