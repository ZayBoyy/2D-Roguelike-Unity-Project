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
    public float hitboxTimer;
    public float cooldown = .75f;
   
    string dir;
    string dirS;

    void Start(){
        hitbox = GetComponent<BoxCollider2D>();
        hitbox.enabled = false;
        hitboxTimer = cooldown;
    }

    void Update() {

    if  (pRender.GetCurrentAnimatorStateInfo(0).IsName("Player Static Left") || pRender.GetCurrentAnimatorStateInfo(0).IsName("Player Run Left")) {
             
            dir = "Swing Animation";
            dirS = "Sword Idle";
    }

    if  (pRender.GetCurrentAnimatorStateInfo(0).IsName("Player Static Right") || pRender.GetCurrentAnimatorStateInfo(0).IsName("Player Run Right")) {
           
            dir = "Swing Animation Right"; 
            dirS = "Sword Idle Right";
            
    }

    if (Input.GetMouseButtonDown(0)) { 
        swinging = true;
        hitbox.enabled = true;   
    }

    if(hitbox.enabled == true){
        this.cooldown -= Time.deltaTime;
        if(cooldown <= 0f){
            cooldown = hitboxTimer;
            hitbox.enabled = false;
        }
    }

    if (swinging == false) {
        anime.Play(dirS);
    }
    
    while (swinging == true) {

        anime.Play(dir);

        if (!anime.GetCurrentAnimatorStateInfo(0).IsName(dir)) {
            swinging = false;
        }
    }
}

   


}



