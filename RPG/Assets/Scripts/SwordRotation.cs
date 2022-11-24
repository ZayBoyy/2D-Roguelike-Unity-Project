using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRotation : MonoBehaviour
{

public PlayerRenderer myRender;
int spot;

    // Start is called before the first frame update
    void Start()
    {
        spot = myRender.getLast();
    }



void Update () {

    if (spot == myRender.getLast()) {
        return;
    }

    else {

        spot = myRender.getLast();

        if (spot == 6) {

            transform.Rotate(0, 0, -90);
            transform.localPosition = new Vector3(.03f, .029f, 0f);
        }
    }
}
}
