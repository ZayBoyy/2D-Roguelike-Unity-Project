using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAI : MonoBehaviour
{
    public Transform transform;

    public float speed = 1.5f;

    public float timer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        timer -= Time.deltaTime;
        if(timer <= 0){
            Destroy(transform.root.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Player"){
            other.GetComponent<PlayerHealth>().damage(15);
            Destroy(transform.root.gameObject);    
        }
        
    }
}
