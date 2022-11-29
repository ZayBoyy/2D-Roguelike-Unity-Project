using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{

    public static readonly string[] staticDirections = {"Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE"};
    public static readonly string[] runDirections = {"Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE"};

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
            lastDirection = DirectionToIndex(direction, 8);
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

    public void snapRight () {
        Vector2 right = new Vector2(2, 0);
            SetDirection(right);
        
    }

    public void snapLeft () {
        Vector2 left = new Vector2(-2, 0);
            SetDirection(left);
        
    }
}
