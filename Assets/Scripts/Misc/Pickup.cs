using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum CollectibleType
    {
        POWERUP,
        SCORE,
        LIFE
    }

    public CollectibleType currentCollectible;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();

            switch (currentCollectible)
            {
                case CollectibleType.LIFE:
                    Debug.Log("Life Collected");
                    GameManager.instance.lives++;
                    break;
                case CollectibleType.POWERUP:
                    Debug.Log("Powerup Collected");
                    pm.StartJumpForceChange();
                    break;
                case CollectibleType.SCORE:
                    Debug.Log("Score Collected");
                    GameManager.instance.score++;
                    break;
            }
            Destroy(gameObject);

        }
    }
}
