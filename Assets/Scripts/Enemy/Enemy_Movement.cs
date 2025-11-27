using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float Speed = 3.0f;
    private bool isChasing;
    private int facingDirection = -1;

    private Rigidbody2D rb;
    public Transform player;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (isChasing && player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * Speed;


            anim.SetFloat("horizontal", Mathf.Abs(direction.x));
            anim.SetFloat("vertical", Mathf.Abs(direction.y));


            if ((player.position.x > transform.position.x && facingDirection == -1) ||
                (player.position.x < transform.position.x && facingDirection == 1))
            {
                Flip();
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;


            anim.SetFloat("horizontal", 0);
            anim.SetFloat("vertical", 0);
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            isChasing = false;
        }
    }
}