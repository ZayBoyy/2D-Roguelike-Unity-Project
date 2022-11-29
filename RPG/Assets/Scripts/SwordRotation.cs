using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRotation : MonoBehaviour
{

public float swingDuration = 0.5f;
public GameObject target;
public SpriteRenderer swordRender;

private float swingTimer = 0f;
private bool swinging = false;
private Vector3 startRot;

private Vector3 startPoint;
private Vector3 midPoint;
private Vector3 endPoint;
float rot = 0;

public PlayerRenderer playerRender;


void Start () {
    startRot = transform.eulerAngles;
    

}

// Update is called once per frame
void Update () {

    

    if (!swinging) {

        startRot = transform.eulerAngles;

        if  (playerRender.getLast() >= 5 ) {
            swordRender.flipX = false;
            transform.localPosition = new Vector3(.12f, .08f, 0f);
            rot = -100;

            startPoint = transform.localPosition;
            midPoint = transform.localPosition + new Vector3(0.4f, -.15f, 0f);
            endPoint = midPoint + new Vector3(-0.4f, -.15f, 0f);  
        }  
        if ( 1 <= playerRender.getLast() && playerRender.getLast() <= 4 ) {

            swordRender.flipX = true;
            transform.localPosition = new Vector3(-.12f, .08f, 0f);
            rot = 100;

            startPoint = transform.localPosition;
            midPoint = transform.localPosition + new Vector3(-0.4f, -.15f, 0f);
            endPoint = midPoint + new Vector3(0.4f, -.15f, 0f);  
        }  
    }   


    if (Input.GetMouseButtonDown(0) && !swinging) {
        swinging = true;
    }   

    if (swinging) {

        swingTimer += Time.deltaTime;

        if (playerRender.getLast() >= 5) {
            playerRender.snapRight();
        }

          if (1 <= playerRender.getLast()  && playerRender.getLast() <= 4) {
            playerRender.snapLeft();
        }
        
        

        if (swingTimer < (swingDuration / 2)) {
            //Controls the rotation from the starting angle to end angle.
            transform.eulerAngles = Vector3.Lerp(startRot, new Vector3(0, 0, rot), swingTimer *2 / swingDuration );   

                Vector3 m1 = Vector3.Lerp( startPoint, midPoint, swingTimer *2 / swingDuration );
                Vector3 m2 = Vector3.Lerp( midPoint, endPoint, swingTimer *2 / swingDuration );
                transform.localPosition = Vector3.Lerp(m1, m2, swingTimer *2 / swingDuration);
        
        }
        if (swingTimer >= (swingDuration / 2)) {
            //Controls the rotation on the way back to the starting angle
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, startRot, (swingTimer-swingDuration/2) *2 / swingDuration );
            
            Vector3 m1 = Vector3.Lerp( endPoint, midPoint, (swingTimer-swingDuration/2) *2 / swingDuration );
                Vector3 m2 = Vector3.Lerp( midPoint, startPoint, (swingTimer-swingDuration/2) *2 / swingDuration );
                transform.localPosition = Vector3.Lerp(m1, m2, (swingTimer-swingDuration/2) *2 / swingDuration );

        }
        

        if (swingTimer > swingDuration) {
            swingTimer = 0f;
            swinging = false;
        }
    }   
  }
} 