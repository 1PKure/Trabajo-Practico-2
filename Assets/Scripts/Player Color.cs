using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [Header("Color")]
    private SpriteRenderer spriteRenderer;
    [SerializeField] private KeyCode changeColor;

    private void Awake()
    {
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ChangeColor()
    {
        if (Input.GetKeyUp(changeColor))
        {
            float red = Random.Range(0, 1.0f);
            float blue = Random.Range(0, 1.0f);
            float green = Random.Range(0, 1.0f);
            float alpha = Random.Range(0.2f, 0.8f);

            spriteRenderer.color = new Color (red, green, blue, alpha); 

        }

    }
}
