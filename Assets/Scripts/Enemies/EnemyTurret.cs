using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class EnemyTurret : MonoBehaviour
{
    public Transform projectileSpawnPointRight;
    public Transform projectileSpawnPointLeft;
    public Projectile projectilePrefab;

    public float projectileForce;
    public float projectileFireRate;
    public float turretFireDistance;
    bool canFire = true;

    float timeSinceLastFire = 0.0f;
    public int health;

    Animator anim;
    SpriteRenderer sr;

    //public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (projectileForce <= 0)
        {
            projectileForce = 7.0f;
        }

        if (projectileFireRate <= 0)
        {
            projectileFireRate = 2.0f;
        }

        if (health <= 0)
        {
            health = 5;
        }

        if (turretFireDistance <= 0)
        {
            turretFireDistance = 5.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playerInstance)
        {
            if (GameManager.instance.playerInstance.transform.position.x > transform.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }

            float distance = Vector2.Distance(transform.position, GameManager.instance.playerInstance.transform.position);

            if (distance <= turretFireDistance)
                canFire = true;
            else
                canFire = false;

            if (canFire)
            {
                if (Time.time >= timeSinceLastFire + projectileFireRate)
                {
                    anim.SetBool("Fire", true);
                }
            }
        }
    }

    public void  Fire()
    {
        timeSinceLastFire = Time.time;
        Projectile temp;
        if (sr.flipX)
        {
            temp = Instantiate(projectilePrefab, projectileSpawnPointRight.position, projectileSpawnPointRight.rotation);
            temp.speed = projectileForce;
        }
        else
        {
            temp = Instantiate(projectilePrefab, projectileSpawnPointLeft.position, projectileSpawnPointLeft.rotation);
            temp.speed = -projectileForce;
        }
        temp.gameObject.GetComponent<SpriteRenderer>().flipX = sr.flipX;
    }

    public void ReturnToIdle()
    {
        anim.SetBool("Fire", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;
            Destroy(collision.gameObject);
            if (health <= 0)
                Destroy(gameObject);
        }
    }
    public void IsSquished()
    {
        
    }
}
