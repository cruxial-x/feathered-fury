using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    private GameObject firePoint;
    public AudioSource audioSource;
    public float projectileForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        float animationLength = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, animationLength);
        firePoint = GameObject.Find("firePoint");
        audioSource = GameObject.Find("Bang").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #pragma warning disable IDE0051 // Used in BordGun animation event
    private void FireProjectile()
    {
        Debug.Log("Firing Projectile");
        audioSource.Play();
        GameObject Projectile = Instantiate(ProjectilePrefab, firePoint.transform.position, transform.rotation);
        Projectile.transform.parent = null;
        // Get the Projectile's rigidbody
        Rigidbody2D ProjectileRb = Projectile.GetComponent<Rigidbody2D>();
        Debug.Log("ProjectilePrefab: " + Projectile.transform.position);

        // Get the direction based on the rotation of the firing object
        Vector2 direction = transform.right;

        // Add force to the Projectile in the direction of the firing object
        ProjectileRb.AddForce(direction * projectileForce, ForceMode2D.Impulse);
    }
    #pragma warning restore IDE0051
}

