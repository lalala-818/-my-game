using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public float maxHealth = 100.0f;
    private float currentHealth;
    public GameObject woodprefab;
    public int woodCount = 5;
    public float woodforce = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Tree Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Tree Destroyed");
            dropwood();
            Destroy(gameObject);
        }
    }

    void dropwood()
    {
        for (int i = 0; i < woodCount; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            GameObject wood = Instantiate(woodprefab, spawnPosition, Quaternion.identity);
            Rigidbody2D rb2d = wood.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f));
                rb2d.AddForce(forceDirection * woodforce, ForceMode2D.Impulse);

            }
        }

        // Update is called once per frame
    }
}
