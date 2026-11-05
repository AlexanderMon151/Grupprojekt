using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float attackTimer = 10f; // Time between attacks
    private float nextAttack; // Time when the next attack can occur
    private Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Adjust the damage value as needed
                //Debug.Log("Player took damage from enemy.");
            }
        }
    }

    public void Update()
    {
        if (Player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                Health playerHealth = collision.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(10); // Adjust the damage value as needed
                    Debug.Log("Player took damage from enemy.");
                }
                attackTimer = 1f; // Reset the attack timer
            }
        }
    }
}
