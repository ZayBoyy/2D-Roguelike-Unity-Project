using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordRotation : MonoBehaviour
{

    bool swinging;
    public PlayerRenderer pRender;
    public SpriteRenderer sRender;
    public Animator anime;
   
    string dir;

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
        
    }
    
    while (swinging == true) {

       
        anime.Play(dir);
        swinging = false;
    }
 }


}