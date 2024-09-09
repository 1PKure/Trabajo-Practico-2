using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, PaddleSize, Defense }
    public PowerUpType powerUpType;
    [SerializeField] private float duration = 5f ;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            ApplyPowerUp(player);
            gameObject.SetActive(false);
        }
    }

    void ApplyPowerUp(PlayerMovement player)
    {
        switch (powerUpType)
        {
            case PowerUpType.SpeedBoost:
                StartCoroutine(ApplySpeedBoost(player));
                break;
            case PowerUpType.PaddleSize:
                StartCoroutine(ApplyPaddleSize(player));
                break;
            case PowerUpType.Defense:
                break;
        }
    }

    IEnumerator ApplySpeedBoost(PlayerMovement player)
    {
        float originalSpeed = player.moveSpeed * Time.deltaTime * 1000;
        player.moveSpeed *= 1.5f * Time.deltaTime * 1000;
        yield return new WaitForSeconds(duration);
        player.moveSpeed = originalSpeed;
    }

    IEnumerator ApplyPaddleSize(PlayerMovement player)
    {
        Vector3 originalSize = player.transform.localScale;
        player.transform.localScale = new Vector3(originalSize.x, originalSize.y * 1.5f, originalSize.z);
        yield return new WaitForSeconds(duration * Time.deltaTime * 1000);
        player.transform.localScale = originalSize; 
    }
}
