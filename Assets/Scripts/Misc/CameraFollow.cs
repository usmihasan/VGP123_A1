using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform player;
    public float minXClamp = 0.0f;
    public float maxXClamp = 35.39f;
    public float minYClamp = -0.99f;
    public float maxYClamp = 0.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        /*
        if (player)
        {
            Vector3 cameraTransform;
            /*cameraTransform = transform.position;

            cameraTransform.x = player.transform.position.x;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);
            transform.position = cameraTransform;

            //take my current position values and put them in the variable
            cameraTransform = player.transform.position;
            cameraTransform = new Vector3(Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp), Mathf.Clamp(cameraTransform.y, minYClamp, maxYClamp), transform.position.z);

            transform.position = cameraTransform;
        }*/

        if (GameManager.instance.playerInstance)
        {
            //create a variable to store the camera's x/y/z position
            Vector3 cameraTransform;

            //take my current position values and put them in the variable
            cameraTransform = transform.position;

            cameraTransform.x = GameManager.instance.playerInstance.transform.position.x;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);
            cameraTransform.y = GameManager.instance.playerInstance.transform.position.y;
            cameraTransform.y = Mathf.Clamp(cameraTransform.y, minYClamp, maxYClamp);
            transform.position = cameraTransform;
        }
    }
}
