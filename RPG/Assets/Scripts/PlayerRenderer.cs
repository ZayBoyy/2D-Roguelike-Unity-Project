using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{

    public static readonly string[] staticDirections = {"Player Static Up", "Player Static Left", "Player Static Left", "Player Static Left", "Player Static Down", "Player Static Right", "Player Static Right", "Player Static Right"};
    public static readonly string[] runDirections = {"Player Run Left", "Player Run Left", "Player Run Left", "Player Run Left", "Player Run Right", "Player Run Right", "Player Run Right", "Player Run Right"};

    Animator animator;
    int lastDirection;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public int getLast () {
        return lastDirection;
    }

   
    public void SetDirection(Vector2 direction)
    {

        //use run state as default
        string[] directionArray = null;

       //measure the magnitude of the input (in case of joystick use)
        if (direction.magnitude < .01f) 
        {
            //May as well be standing still with this level of input, so we'll use static states
            directionArray = staticDirections;
        }
        else
        {
            //determine which direction we're going
            //use DirectionToIndex to get the index of the slice from the direction vector (I don't get it either)
            //save it to lastDirection
            directionArray = runDirections;
            
            if (DirectionToIndex(direction, 8) == 0 || DirectionToIndex(direction, 8) == 4) {
                
            }
            else {
            lastDirection = DirectionToIndex(direction, 8);
            }
        
        }
        
        animator.Play(directionArray[lastDirection]);

    }

    
    public static int DirectionToIndex (Vector2 dir, int sliceCount) 
    {
        Vector2 normDir = dir.normalized;

        float step = 360f/sliceCount;


        float halfstep = step/2;
        


        float angle = Vector2.SignedAngle(Vector2.up, normDir);

        angle += halfstep;

        if (angle < 0) 
        {
            angle +=360;
        }

        float stepCount = angle / step;

        return Mathf.FloorToInt(stepCount);
    }


}
