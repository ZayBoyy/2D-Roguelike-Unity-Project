using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{

    public float speed = 1.0f;

    public Transform enemyT;
    public Vector3 pos;

    public GameObject player;
    public Transform playerT;
    public Vector3 playerPos;

    public float distToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        enemyT = GetComponent<Transform>();
        pos = enemyT.position;

        player = GameObject.Find("Player");
        playerT = player.transform;
        playerPos = playerT.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerT.position;
        pos = enemyT.position;
        Vector3 displacementToPlayer = playerPos - pos;
        distToPlayer = displacementToPlayer.magnitude;
        Vector3 directionToPlayer = displacementToPlayer / distToPlayer;

        if(distToPlayer <= 2.5f){
            enemyT.position += speed*directionToPlayer*Time.deltaTime;
        }
    }
}
