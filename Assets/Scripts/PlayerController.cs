using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 200f;
    public float thrustForce = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 8f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotation
        float rotation = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);

        // Thrust
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * thrustForce);
        }

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        brb.velocity = transform.up * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            GameManager.Instance.GameOver();
            gameObject.SetActive(false);
        }
    }
} 