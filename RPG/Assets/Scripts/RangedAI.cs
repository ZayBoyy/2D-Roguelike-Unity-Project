using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAI : MonoBehaviour
{

    public float speed = 1.0f;

    public Transform enemyT;
    public Vector3 pos;

    public GameObject player;
    public Transform playerT;
    public Vector3 playerPos;

    public float distToPlayer;

    public GameObject projectile;

    public const float maxProjTimer = 2f;
    public float projTimer = 0f;

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

        if(distToPlayer <= 5f){
            if(distToPlayer <= 2f){
                enemyT.position += -1*speed*directionToPlayer*Time.deltaTime;
            }else{
                if(projTimer <= 0){
                    GameObject proj;
                    proj = Instantiate(projectile, enemyT.position + enemyT.forward, enemyT.rotation);
                    proj.transform.up = directionToPlayer;
                    projTimer = maxProjTimer;
                }else{
                    projTimer -= Time.deltaTime;
                } 
            } 
        }
    }
}