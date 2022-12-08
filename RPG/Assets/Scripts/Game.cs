using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    
    public List<GameObject> spawns = new List<GameObject>();

    public GameObject enemy;

    public int enemyCount;
    public List<GameObject> enemies;

    public float spawnCD = 1.0f;
    private int i = 0;

    public TextMeshProUGUI roundText;
    public int roundNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        spawns.Add(spawn1);
        spawns.Add(spawn2);
        spawns.Add(spawn3);
        spawns.Add(spawn4);

        enemyCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(i < enemyCount){
            if(spawnCD <= 0){
                enemies.Add(Instantiate(enemy, spawns[i%4].transform.position, spawns[i%4].transform.rotation));
                spawnCD = 1.0f;
                i += 1;
            }else{
                spawnCD -= Time.deltaTime;
            }
        }else if(enemies.Count == 0){
            i = 0;
            enemyCount +=2;
            spawnCD = 3.0f;
            roundNum++;
            roundText.text = String.Format("Round {0}", roundNum);
        }

        for(int j = enemies.Count - 1; j>=0; j--){
            if(enemies[j] == null){
                enemies.RemoveAt(j);
            }
        }
    }
}
