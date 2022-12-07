using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Collision");
        if(other.gameObject.tag == "Enemy"){
            other.GetComponent<EnemyHealth>().damage(35);  
        }
    }
}
