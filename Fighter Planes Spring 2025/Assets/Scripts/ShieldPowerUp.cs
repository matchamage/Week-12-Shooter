using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldPowerUp : MonoBehaviour
{
    public float duration = 5f; 
    public GameObject shieldVisualPrefab; 
    public AudioClip powerUpSound;       

    private GameObject currentShieldVisual;
    private Player player;
    private bool isShielded = false;
    private float shieldEndTime;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isShielded)
        {
            player = other.GetComponent<Player>();
            if (player != null)
            {
                ActivateShield();
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (isShielded && Time.time > shieldEndTime)
        {
            DeactivateShield();
        }
    }

public void ActivateShield()
{
    if (player != null)
    {
        player.SetShield(true, shieldVisualPrefab);
        shieldEndTime = Time.time + duration;

        if (powerUpSound != null && player.GetComponent<AudioSource>() != null)
        {
            player.GetComponent<AudioSource>().PlayOneShot(powerUpSound);
        }
        else if (powerUpSound != null)
        {
            Debug.LogWarning("Power-up sound assigned but no AudioSource found on the Player.");
        }
    }
}

public void DeactivateShield()
{
    if (player != null)
    {
        player.SetShield(false, null);
    }
}
}