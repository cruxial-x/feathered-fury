using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    private GameObject firePoint;
    private AudioSource audioSource;
    public float projectileForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        float animationLength = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, animationLength);
        firePoint = GameObject.Find("firePoint");
        audioSource = firePoint.GetComponent<AudioSource>();
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
        GameObject Projectile = Instantiate(ProjectilePrefab, firePoint.transform);
        // Get the Projectile's rigidbody
        Rigidbody2D ProjectileRb = Projectile.GetComponent<Rigidbody2D>();
        Debug.Log("ProjectilePrefab: " + Projectile.transform.position);
        // Add force to the Projectile
        ProjectileRb.AddForce(Vector2.right * projectileForce, ForceMode2D.Impulse);
    }
    #pragma warning restore IDE0051
}

