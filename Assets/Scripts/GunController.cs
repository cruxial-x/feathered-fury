using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    public GameObject ProjectilePrefab;

    public float projectileForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        float animationLength = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Debug.Log("Animation Length: " + animationLength);
        StartCoroutine(FireProjectileAtHalfAnimation(animationLength / 2));
        Destroy(gameObject, animationLength);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FireProjectileAtHalfAnimation(float delay)
    {
        // Wait for half the animation time
        yield return new WaitForSeconds(delay);
        // Fire the Projectile
        FireProjectile();
    }

    private void FireProjectile()
    {
        GameObject firePoint = GameObject.Find("firePoint");
        Debug.Log("firePoint: " + firePoint.transform.position); 
        // Create a new Projectile at the bird's position

        GameObject Projectile = Instantiate(ProjectilePrefab, firePoint.transform);
        // Get the Projectile's rigidbody
        Rigidbody2D ProjectileRb = Projectile.GetComponent<Rigidbody2D>();
        Debug.Log("ProjectilePrefab: " + Projectile.transform.position);
        // Add force to the Projectile
        ProjectileRb.AddForce(Vector2.right * projectileForce, ForceMode2D.Impulse);
    }
}

