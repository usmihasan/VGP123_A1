using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerFire : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;

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
            projectileSpeed = 7.0f;

        if (!spawnPointLeft || !spawnPointRight || !projectilePrefab)
            Debug.Log("Unity inspector values not set");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isFiring", true);
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

    }

    void ResetFireAnimation()
    {
        anim.SetBool("isFiring", false);
        FireProjectile();
    }
}
