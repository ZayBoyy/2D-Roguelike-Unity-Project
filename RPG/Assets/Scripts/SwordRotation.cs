using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordRotation : MonoBehaviour
{

    bool swinging;
    public PlayerRenderer pRender;
    public SpriteRenderer sRender;
    public Animator anime;

    public BoxCollider2D hitbox;
    public float hitboxTimer = .75f;
   
    string dir;

    void Start(){
        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
    }

    void Update() {

    if  (pRender.getLast() <= 3) {
             
            sRender.flipX = true;
            sRender.transform.position = new Vector3(-0.16f, 0f, 0f);
            dir = "Swing Animation";
    }

    if  (pRender.getLast() >= 4 ) {
           
            sRender.flipX = false;    
            sRender.transform.position = new Vector3(0.16f, 0f, 0f);  
            dir = "Swing Animation Right";
            
    }

    if (Input.GetMouseButtonDown(0)) { 
        swinging = true;
        hitbox.enabled = true;   
    }

    if(hitbox.enabled == true){
        hitboxTimer -= Time.deltaTime;
        if(hitboxTimer <= 0f){
            hitboxTimer = 0.75f;
            hitbox.enabled = false;
        }
    }
    
    while (swinging == true) {

       
        anime.Play(dir);
        swinging = false;
    }
 }


}
