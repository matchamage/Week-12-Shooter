using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isShielded = false;
    public AudioClip powerDownSound;

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 8.38f;
    private float verticalScreenLimit = 6.5f;
    private float stopYPositionUpper = 0f;
    private float stopYPositionLower = -4.47f;


    void Start()
    {
        playerSpeed = 8f;
    }

    void Update()
    {
        Movement();
    }

    void Movement ()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
       float clampedY = Mathf.Clamp(transform.position.y, stopYPositionLower, stopYPositionUpper);
        Vector3 newPosition = transform.position;
        newPosition.y = clampedY;
        transform.position = newPosition;
    }
    private void OnTriggerEnter(Collider other) 
    {
    if (other.CompareTag("Coin") && !isShielded)
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(1);
        }
        else
        {
            Debug.LogError("ScoreManager Instance is null.");
        }
        Destroy(other.gameObject);
    }
    else if (other.CompareTag("Enemy")) 
    {
        if (isShielded)
        {
            Debug.Log("Shield absorbed enemy collision!");
            Destroy(other.gameObject);
            DeactivateShield(); 
        }
        else
        {
            Debug.Log("Player hit by enemy!");
        }
    }
    else if (other.CompareTag("ShieldPowerUp") && !isShielded)
    {
    }
}

    
    public void SetShield(bool active, GameObject shieldVisual)
{
    isShielded = active;

    if (active && shieldVisual != null)
    {
        Instantiate(shieldVisual, transform.position, Quaternion.identity, transform);
    }
    else
    {
        GameObject existingShield = transform.Find("ShieldVisual(Clone)")?.gameObject;
        if (existingShield != null)
        {
            Destroy(existingShield);
        }
    }
}

    public void DeactivateShieldSound()
    {
        if (powerDownSound != null && GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().PlayOneShot(powerDownSound);
        }
        else if (powerDownSound != null)
        {
            Debug.LogWarning("Power-down sound assigned but no AudioSource found on the Player.");
        }
    }


    public bool IsShielded()
    {
        return isShielded;
    }
    private void DeactivateShield()
{
    isShielded = false;
    Debug.Log("Shield deactivated.");
    DeactivateShieldSound(); // Play the shield deactivation sound
}
}

