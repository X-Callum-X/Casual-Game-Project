using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int speed;
    public int maxSpeed;
    public int damage;
    public int attackRate;
    public float attackRange;
    public int health = 10;

    private float timeBetweenAttacks;
    private float maxTimeBetweenAttacks;

    public Transform attackPos;
    public LayerMask enemyLayer;
    public LayerMask baseLayer;

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        transform.position = pos;
    }

    private void Update()
    {
        timeBetweenAttacks += Time.deltaTime;

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
        Collider2D[] baseToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, baseLayer);

        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            StopAllCoroutines();
            StartCoroutine(StopToAttack());

            if (timeBetweenAttacks >= attackRate)
            {
                enemiesToDamage[i].GetComponent<EnemyManager>().health -= damage;

                timeBetweenAttacks = maxTimeBetweenAttacks;
            }
        }

        for (int i = 0; i < baseToDamage.Length; i++)
        {
            StopAllCoroutines();
            StartCoroutine(StopToAttack());

            if (timeBetweenAttacks >= attackRate)
            {
                baseToDamage[i].GetComponent<BaseManager>().baseHealth -= damage;

                timeBetweenAttacks = maxTimeBetweenAttacks;
            }
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator StopToAttack()
    {
        speed = 0;
        yield return new WaitForSeconds(attackRate);
        speed = maxSpeed;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
