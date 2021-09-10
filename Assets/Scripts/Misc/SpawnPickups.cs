using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public Pickup[] pickupPrefabArray;

    // Start is called before the first frame update
    void Start()
    {
        int randValue = Random.Range(0, pickupPrefabArray.Length);
        Instantiate(pickupPrefabArray[randValue], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
