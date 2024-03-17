using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private BirdController bird;
    // Start is called before the first frame update
    void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        GameObject[] scoreZones = GameObject.FindGameObjectsWithTag("ScoreZone");
        foreach (GameObject scoreZone in scoreZones)
        {
            Physics2D.IgnoreCollision(scoreZone.GetComponent<Collider2D>(), collider);
        }
        bird = GameObject.Find("Bird").GetComponent<BirdController>();
        // Destroy the Projectile after 5 seconds
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pipe"))
        {
            bird.DecreaseScore();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Cloud"))
        {
            bird.IncrementScore();
            bird.IncrementCloudHitCount();
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
