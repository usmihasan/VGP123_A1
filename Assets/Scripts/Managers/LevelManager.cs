using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int startingLives;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.lives = startingLives;
        GameManager.instance.SpawnPlayer(spawnPoint);
        GameManager.instance.currentLevel = this;
    }
}
