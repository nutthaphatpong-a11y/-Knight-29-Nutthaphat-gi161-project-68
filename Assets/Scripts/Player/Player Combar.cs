using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Player player; // รับ Player มา

    public Animator anim;
    public float Cooldown = 2;
    private float timer;
    public float weaponRange = 1;
    public LayerMask enemyLayer;
    public Transform attackPoint;

    public void Init(Player _player)
    {
        player = _player;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("IsAttacking", true);
            timer = Cooldown;
        }
    }

    public void DealDamage()
    {
        if (attackPoint == null)
        {
            Debug.LogError("❌ AttackPoint is NOT assigned in PlayerCombat!");
            return;
        }

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            Enemy_Health enemyHealth = enemies[0].GetComponent<Enemy_Health>();

            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(-player.baseDamage);
            }
            else
            {
                Debug.LogWarning("⚠ Enemy hit doesn't have Enemy_Health component!");
            }
        }
    }


    public void FinishAttack()
    {
        anim.SetBool("IsAttacking", false);
    }
}
