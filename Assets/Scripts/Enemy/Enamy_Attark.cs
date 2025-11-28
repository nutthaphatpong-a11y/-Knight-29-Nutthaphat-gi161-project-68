using UnityEngine;

public class Enamy_Attark : MonoBehaviour
{
    
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.GetComponent<Player>().ChangeHealth(-damage);
        }
    }

}
