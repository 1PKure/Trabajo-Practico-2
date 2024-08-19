using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //private int score = 10;
    //private float life = 100f;
    private SpriteRenderer spriteRenderer;
    [Header("Movement")]
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private KeyCode KeyUp;
    [SerializeField] private KeyCode KeyDown;
    [SerializeField] private KeyCode KeyLeft;
    [SerializeField] private KeyCode KeyRight;
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;
    [Header("Rotate")]
    [SerializeField] private float degree = 10f;
    [SerializeField] private float rotation = 0;

  
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerOne.SetActive(true);
        playerTwo.SetActive(true);
    }
    void Update()
    {
        Vector3 pos = transform.position;
      

        
        if (Input.GetKey(KeyUp))
        {
            pos.y += speed;
        }
        if (Input.GetKey(KeyLeft))
        {
            pos.x -= speed;
        }
        if (Input.GetKey(KeyDown))
        {
            pos.y -= speed;
        }
        if (Input.GetKey(KeyRight))
        {
            pos.x += speed;
        }

        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            rotation -= degree;
            transform.Rotate(0, 0, rotation);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            rotation += degree;
            transform.Rotate(0, 0, rotation);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            
            spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f);
        }



    }

    public void SetMovementSpeed(float newSpeed)
    {
        if (newSpeed > 1)
        {
            return;
        }
       speed = newSpeed;
    }

    public float GetMovementSpeed()
    {
        return speed;
    }






}
