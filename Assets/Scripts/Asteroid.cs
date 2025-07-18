using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 2f;
    public int splits = 2;
    public GameObject asteroidPrefab;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitCircle.normalized * speed;
        float size = Random.Range(minSize, maxSize);
        transform.localScale = Vector3.one * size;
    }

    public void Split()
    {
        if (transform.localScale.x / 2f >= minSize)
        {
            for (int i = 0; i < splits; i++)
            {
                Vector3 pos = transform.position + (Vector3)(Random.insideUnitCircle * 0.5f);
                GameObject newAsteroid = Instantiate(asteroidPrefab, pos, Quaternion.identity);
                newAsteroid.transform.localScale = transform.localScale / 2f;
            }
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameManager.Instance.AddScore(10);
            Split();
            Destroy(collision.gameObject);
        }
    }
} 