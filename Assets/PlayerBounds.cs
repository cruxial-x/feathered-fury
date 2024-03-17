using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float leftLimit = -10;
    public float rightLimit = 10;
    public float topLimit = 10;
    public float bottomLimit = -10;

    // Update is called once per frame
    void Update()
    {
        // Restrict the player's position to be within the defined limits
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit)
        );
        transform.position = new Vector3(clampedPosition.x, clampedPosition.y, transform.position.z);
    }

    // Draw gizmos in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Draw a box around the player
        Gizmos.DrawWireCube(transform.position, new Vector3(rightLimit - leftLimit, topLimit - bottomLimit, 0));
    }
}