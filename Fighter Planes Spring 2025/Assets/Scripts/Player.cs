using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
        if (other.CompareTag("Coin"))
        {
        ScoreManager.Instance.AddScore(1);
        Destroy(other.gameObject);
        }
    }
}

