using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameController gameController;
    public Text scoreText;
    public Text highScoreText;
    public int score = 0;
    private int cloudHitCount = 0;
    private int highScore;
    private bool isAlive;
    public float flapForce = 5;
    public List<IPowerUp> activePowerUps = new();

    // Start is called before the first frame update
    void Start()
    {
        // highScore = PlayerPrefs.GetInt("HighScore", 0);
        // UpdateHighScoreText();
        UpdateScoreText();
        isAlive = true;
    }

// private float lastFlapTime;
// public float flightTime = 0.5f;
// public float fallRotationSpeed = 3;
// private bool justFlapped = false;

void Update()
{
    // Flap detection with smoothed force application
    if(Input.GetKeyDown(KeyCode.Space))
    {
        rb.velocity = Vector2.up * flapForce;
        // lastFlapTime = Time.time;
        // justFlapped = true;
    }
    foreach (var powerUp in activePowerUps)
    {
        powerUp.Update();
    }

    // if (Time.time - lastFlapTime < flightTime && justFlapped)
    // {
    //     // Maintain upward angle for a short duration after flapping
    //     transform.rotation = Quaternion.Euler(0, 0, 25); // Adjust this angle as needed
    // }
    // else
    // {
    //     justFlapped = false;
    //     // Calculate and apply angle based on vertical velocity
    //     float angle = rb.velocity.y * 10;
    //     angle = Mathf.Clamp(angle, -90, 25);
    //     // Interpolate rotation over time for smoother transition
    //     Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * fallRotationSpeed);
    // }

    if (!isAlive)
    {
        gameController.GameOver();
        Destroy(gameObject);
    }
}

    public int GetCloudHitCount()
    {
        return cloudHitCount;
    }
    public void IncrementCloudHitCount()
    {
        cloudHitCount++;
    }
    public void ResetCloudHitCount()
    {
        cloudHitCount = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Cloud"))
        {
            isAlive = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered");
        if (collider.gameObject.CompareTag("ScoreZone"))
        {
            IncrementScore();
        }
        if (collider.gameObject.TryGetComponent<IPowerUp>(out var powerUp))
        {
            // // Remove any existing powerups before applying the new one?
            // foreach (var oldPowerUp in activePowerUps)
            // {
            //     oldPowerUp.Remove(this);
            // }
            powerUp.Apply(this);
            activePowerUps.Add(powerUp);
            Destroy(collider.gameObject);
        }
    }
        // Call this method when the bird clears a pipe
    public void IncrementScore(int count = 1)
    {
        score += count;
        UpdateScoreText();
        if (score > highScore)
        {
            highScore = score;
            // PlayerPrefs.SetInt("HighScore", highScore);
            // UpdateHighScoreText();
        }
    }
    public void DecreaseScore()
    {
        score--;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "  Score: " + score;
    }
    private void UpdateHighScoreText()
    {
        highScoreText.text = "  High Score: " + highScore;
        Debug.Log(highScoreText.text);
    }
}
