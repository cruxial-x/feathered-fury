using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        // If the object has moved off the screen to the left, destroy it
        if (transform.position.x < -10f) // Adjust this value as needed
        {
            Destroy(gameObject);
        }
    }
}
