using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    private float limitY = 3.0f;
    private float limitX = 10;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Vector2 position = transform.position;
        position.y = Mathf.Clamp(position.y, -limitY, limitY);
        position.x = Mathf.Clamp(position.x, -limitX, limitX);
        transform.position = position;


        if (gameObject.name == "PlayerOne")
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (gameObject.name == "PlayerTwo")
        {
            movement.y = Input.GetAxisRaw("Vertical2");
        }
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = new Vector2(rb.velocity.x, movement.y * moveSpeed * Time.deltaTime * 1000);
    }
    public void SetMovementSpeed (float newSpeed)
    {
        if (newSpeed > 1)
        {
            return;
        }
        moveSpeed = newSpeed * Time.deltaTime * 1000;
    }

    public float GetMovementSpeed()
    { 
        return moveSpeed; 
    }   
}
