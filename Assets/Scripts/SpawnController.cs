using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject cloudPrefab;
    public GameObject bossCloudPrefab;
    public BirdController bird;
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
        Collider2D playerCollider = GameObject.Find("Bird")?.GetComponent<Collider2D>();
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
}
