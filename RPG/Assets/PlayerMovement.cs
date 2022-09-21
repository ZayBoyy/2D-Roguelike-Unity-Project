using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   PlayerRenderer isoRenderer;

    Rigidbody2D player;

    public float movementSpeed = 1f;




    void Start()
    {
     player = GetComponent<Rigidbody2D>();
    isoRenderer = GetComponentInChildren<PlayerRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = player.position;
        float horizonalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 inputVector = new Vector2(horizonalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);

        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPosition = currentPosition + movement *Time.fixedDeltaTime;

        isoRenderer.SetDirection(movement);
        player.MovePosition(newPosition);
       
    }

}
