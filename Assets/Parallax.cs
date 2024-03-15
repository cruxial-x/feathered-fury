using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject background;
    public float speed = 0.5f;

    private GameObject background2;
    private float spriteWidth;

    void Start()
    {
        float pixelSize = 1f / 16;
        // Duplicate the background sprite
        background2 = Instantiate(background, new Vector3(background.transform.position.x + background.GetComponent<SpriteRenderer>().bounds.size.x - pixelSize, background.transform.position.y, background.transform.position.z), Quaternion.identity);

        // Get the width of the sprite
        spriteWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move the sprites to the left
        background.transform.Translate(-speed * Time.deltaTime, 0, 0);
        background2.transform.Translate(-speed * Time.deltaTime, 0, 0);

        // If one sprite is off the screen, move it to the right side of the other sprite
        if (background.transform.position.x < -spriteWidth)
        {
            background.transform.position = new Vector3(background2.transform.position.x + spriteWidth, background.transform.position.y, background.transform.position.z);
        }
        if (background2.transform.position.x < -spriteWidth)
        {
            background2.transform.position = new Vector3(background.transform.position.x + spriteWidth, background2.transform.position.y, background2.transform.position.z);
        }
    }
}