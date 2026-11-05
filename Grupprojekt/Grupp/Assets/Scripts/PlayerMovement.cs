using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D RB;
    public float speed = 5f;
    private float moveX;
    private float moveY;
    private Vector2 Movement;

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 Movement = new Vector2(moveX, moveY).normalized;
        RB.linearVelocity = Movement * speed;
    }
}
