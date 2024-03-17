using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject cloudPrefab;
    public GameObject bossCloudPrefab;
    public BirdController bird;
    public List<GameObject> powerUps;
    public float pipeSpawnRate = 2f;
    public float cloudSpawnRate = 2f;
    public float delay = 3f;
    public int cloudsBeforeEvil = 5;
    public float cloudOffset = 2f;
    public float minHeight;
    public float maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayedStart", delay);
    }

    void DelayedStart()
    {
        InvokeRepeating("SpawnPipe", 0, pipeSpawnRate);
        InvokeRepeating("SpawnCloud", 0, cloudSpawnRate);
    }

    void Update()
    {
        if (bird.GetCloudHitCount() >= cloudsBeforeEvil && !GameObject.Find("BOSS CLOUD(Clone)"))
        {
            SpawnBossCloud();
        }

        SpawnPowerUp();
        
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minHeight, maxHeight);
        Vector2 spawnPosition = new Vector2(transform.position.x, randomY);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
    void SpawnCloud()
    {
        float randomY = Random.Range(minHeight, maxHeight + cloudOffset);
        Vector3 spawnPosition = new(transform.position.x, randomY, 1);
        GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
        Collider2D cloudCollider = newCloud.GetComponent<Collider2D>();
        Collider2D playerCollider = GameObject.Find("Bird").GetComponent<Collider2D>();
        if (cloudCollider != null && playerCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, cloudCollider);
        }
    }
    void SpawnBossCloud()
    {
        Vector2 spawnPosition = new(transform.position.x, transform.position.y);
        Instantiate(bossCloudPrefab, spawnPosition, Quaternion.identity);
    }
    private readonly Dictionary<IPowerUp, GameObject> instantiatedPowerUps = new();

    void SpawnPowerUp()
    {
        foreach (var powerUpPrefab in powerUps)
        {   
            var powerUp = powerUpPrefab.GetComponent<IPowerUp>();
            bool birdNeedsPoints = bird.score < powerUp.PointsRequired;
            bool birdHasPowerup = bird.activePowerUps.Any(activePowerUp => activePowerUp.PowerUpName == powerUp.PowerUpName);
            if(birdNeedsPoints || birdHasPowerup)
            {
                continue;
            }
            if (!instantiatedPowerUps.ContainsKey(powerUp) || instantiatedPowerUps[powerUp] == null)
            {
                instantiatedPowerUps[powerUp] = Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
