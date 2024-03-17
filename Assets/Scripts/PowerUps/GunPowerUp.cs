using UnityEngine;

public class GunPowerUp : MonoBehaviour, IPowerUp
{
    public GameObject gunPrefab;
    [SerializeField] string powerUpName = "Gun";
    public string PowerUpName { get { return powerUpName; } }
    [SerializeField] int pointsRequired = 1;
    public int PointsRequired { get { return pointsRequired; } }
    private BirdController bird;

    public void Apply(BirdController bird)
    {
        this.bird = bird;
    }

    public void Remove(BirdController bird)
    {
        this.bird = null;
    }

    public void Update()
    {
        if (bird != null && Input.GetButtonDown("Fire1"))
        {
            ShootGun();
        }
    }
    private void ShootGun()
    {
        // Check if an instance of gunPrefab already exists
        if (FindObjectOfType<DestroyAfterAnimation>() == null)
        {
            // If not, instantiate a new one
            GameObject gun = Instantiate(gunPrefab, bird.transform);

            // Get the direction to the mouse
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePosition - bird.transform.position).normalized;

            // Calculate the rotation to face the mouse
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, -45, 45);
            // Set the rotation of the gun
            gun.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}