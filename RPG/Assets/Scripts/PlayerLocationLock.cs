using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationLock : MonoBehaviour
{

    public Transform player;

    public Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       Vector3 newPosition = player.transform.position + cameraOffset;
       transform.position = newPosition; 
    }
}
