using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombar : MonoBehaviour
{
    public Animator anim;

    public float Cooldown = 2;
    private float timer;

    public float weaponRange = 1;
    public LayerMask enemyLayer;
    public int Damage = 1;
    public Transform attackPoint;
    public int Exp = 0;
    public int maxExp = 1;
    public int levelPlayer = 1;

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

    public void LevelUP()
    {
        Exp++;

        if (Exp >= maxExp)
        {
            Exp = 0;
            maxExp++;
            levelPlayer++;
            Damage++;
            Debug.Log("Player Level " + levelPlayer );
        }
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Enemy_Health>().ChangeHealth(-Damage);
        }
    }

    public void FinishAttack()
    {
        anim.SetBool("IsAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
