using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedIncrement = 0.1f;
    [SerializeField] private float speedIncreaseInterval = 10f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("IncreaseSpeed", speedIncreaseInterval, speedIncreaseInterval);
        LaunchBall();
    }

    void IncreaseSpeed()
    {
        rb.velocity *= (1 + speedIncrement) * Time.deltaTime * 1000;
    }
    void LaunchBall()
    {
        rb.velocity = new Vector2(speed, speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity *= (0.01f + speedIncrement * Time.deltaTime * 1000);
        }
        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    Vector2 normal = collision.contacts[0].normal;
        //    Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //    rb.velocity = Vector2.Reflect(rb.velocity, normal);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Pasó la pelota");
        }

    }

}
