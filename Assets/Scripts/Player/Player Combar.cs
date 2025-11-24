using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombar : MonoBehaviour
{
    public Animator anim;

    public float Cooldown = 2;
    private float timer;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; 
        }
    }

    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("IsAttacking", true);
            timer = Cooldown;
        }
            
    }

    public void FinishAttack()
    {
        anim.SetBool("IsAttacking", false);
    }
}
