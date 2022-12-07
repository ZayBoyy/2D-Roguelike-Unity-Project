using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public float timeSinceLastDamage = 0f;

    public float regenTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastDamage += Time.deltaTime;
        if(timeSinceLastDamage >= 3.0f){
            if(regenTimer <= 0f){
                health += 3;
                health = Mathf.Clamp(health, 0, 100);
                regenTimer = 1f;
            }else{
                regenTimer -= Time.deltaTime;
            }
        }
    }

    public void damage(int x){
        health -= x;
        timeSinceLastDamage = 0f;
    }
}
