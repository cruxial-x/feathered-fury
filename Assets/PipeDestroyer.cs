using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "ScoreZone")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Cloud")
        {
            Debug.Log("Cloud Destroyed");
            Destroy(collision.gameObject);
        }
    }
}
