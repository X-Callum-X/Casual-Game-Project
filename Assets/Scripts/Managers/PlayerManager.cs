using System.Collections;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float damage;
    public float attackRate;
    public float attackRange;
    public float health = 10;
    public float maxHealth = 10;

    private float timeBetweenAttacks;
    private float maxTimeBetweenAttacks;

    public Transform attackPos;
    public LayerMask enemyLayer;
    public LayerMask baseLayer;
    private HealthbarController healthbarController;

    private void Start()
    {
        healthbarController = GetComponentInChildren<HealthbarController>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;

        transform.position = pos;
    }

    private void Update()
    {
        healthbarController.SetHealth(health, maxHealth);
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
