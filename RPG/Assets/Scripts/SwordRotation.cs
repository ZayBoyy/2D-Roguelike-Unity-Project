using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordRotation : MonoBehaviour
{

    bool swinging;
    public Animator pRender;
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

        

    if  (pRender.GetCurrentAnimatorStateInfo(0).IsName("Player Static Left") || pRender.GetCurrentAnimatorStateInfo(0).IsName("Player Run Left")) {
             
            dir = "Swing Animation";
    }

    if  (pRender.GetCurrentAnimatorStateInfo(0).IsName("Player Static Right") || pRender.GetCurrentAnimatorStateInfo(0).IsName("Player Run Right")) {
           
               
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
