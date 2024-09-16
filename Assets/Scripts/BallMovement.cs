using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedIncrement = 0.1f;
    [SerializeField] private TextMeshProUGUI scoreTextPlayerOne;
    [SerializeField] private TextMeshProUGUI scoreTextPlayerTwo;
    private int scorePlayerOne = 0;
    private int scorePlayerTwo = 0;
    public Vector2 initialPosition = new Vector2(0, 0);
    public float initialForce = 5f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(LaunchBallAfterDelay(0.1f));
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = initialPosition;
        StartCoroutine(LaunchBallAfterDelay(1f));
    }
    IEnumerator LaunchBallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector2 launchDirection = Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right;
        rb.AddForce(launchDirection * initialForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity *= (0.01f + speedIncrement * Time.deltaTime * 1000);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.Reflect(rb.velocity, normal);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GoalBlue")
        {
            scorePlayerOne++;
            UpdateScore();
            ResetBall();
        }
        else if (collision.gameObject.tag == "Goal Green")
        {
            scorePlayerTwo++;
            UpdateScore();
            ResetBall();
        }
    }

    void UpdateScore()
    {
        scoreTextPlayerOne.text = scorePlayerOne.ToString();
        scoreTextPlayerTwo.text = scorePlayerTwo.ToString();
    }

    private void Update()
    {
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed * Time.deltaTime * 1000;
        }
    }

}
