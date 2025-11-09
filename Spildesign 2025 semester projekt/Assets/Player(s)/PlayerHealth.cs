using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    float healthLossCooldown = 0;
    public string playerName;
    private Collider2D playerCollider;

    public int bonusHealth = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log(playerName + " was destroyed");
            Destroy(gameObject);
        }

        if (healthLossCooldown > 0)
        {
            healthLossCooldown -= Time.deltaTime;
        }
        else if (healthLossCooldown < 0)

        {
            healthLossCooldown = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (healthLossCooldown == 0 && gameObject.name != "Player1")
        {
            LoseHealth(1);
            healthLossCooldown += 0;
            Debug.Log(playerName +" lost 20 health");
        }
        else if (healthLossCooldown == 0 && collision.name != "PlayerBullet(Clone)")
        {
            LoseHealth(1);
            healthLossCooldown += 0;
            Debug.Log(playerName + " lost 20 health");
        }
    }

    void LoseHealth(int damage)
    {
        if (bonusHealth > 0)
        {
            bonusHealth -= damage;
        }
        else if (bonusHealth <= 0)
        {
            health -= damage;
        }

    }
        
}
