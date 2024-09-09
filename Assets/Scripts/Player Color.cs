using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [Header("Color")]
    private SpriteRenderer spriteRenderer;
    [SerializeField] private KeyCode changeColorKey = KeyCode.Space;
    [SerializeField] private KeyCode resetColorKey = KeyCode.R;
    private Color defaultColor = Color.white;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }
    private void Update()
    {
        if (Input.GetKeyDown(changeColorKey))
        {
            ChangeColor();
        }

        if (Input.GetKeyDown(resetColorKey))
        {
            ResetColor();
        }
    }

    private void ChangeColor()
    {

        float red = Random.Range(0, 1.0f);
        float blue = Random.Range(0, 1.0f);
        float green = Random.Range(0, 1.0f);
        float alpha = 1.0f;
        //Debug.Log($"Color: R={red}, G={green}, B={blue}, A={alpha}");
        spriteRenderer.color = new Color(red, green, blue, alpha);
    }

    private void ResetColor()
    {
        spriteRenderer.color = defaultColor;
    }
}
