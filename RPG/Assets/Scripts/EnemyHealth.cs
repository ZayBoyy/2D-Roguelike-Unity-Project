using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    public bool immune = false;
    public float iframes = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(immune == true){
            iframes -= Time.deltaTime;
            if(iframes <= 0){
                immune = false;
                iframes = 0.5f;
            }
        }

        if(health <= 0){
            Destroy(transform.root.gameObject); 
        }
    }

    public void damage(int x){
        if(immune == false){
            immune = true;
            health -= x;
        }
    }
}
