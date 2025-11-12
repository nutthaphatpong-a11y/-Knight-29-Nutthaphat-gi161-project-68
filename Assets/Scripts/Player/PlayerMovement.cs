using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public int facingDirection = 1; 

    public Rigidbody2D rb;
    public Animator anim;

    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        if(horizontal > 0 && transform.localScale.x < 0 || 
            horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;

    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
