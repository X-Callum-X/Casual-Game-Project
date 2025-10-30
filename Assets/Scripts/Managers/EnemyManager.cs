using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
    [Header("Variables")]
    public float speed;
    public float maxSpeed;
    public float damage;
    public float attackRate;
    public float attackRange;
    public float health = 10;
    public float maxHealth = 10;

    private float attackTimer;
    private float resetAttackTimer;

    [Header("References")]
    public Transform attackPos;
    public LayerMask playerUnitLayer;
    public LayerMask baseLayer;
    [SerializeField] private HealthbarController healthbarController;

    private void Start()
    {
        healthbarController = GetComponentInChildren<HealthbarController>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;

        transform.position = pos;
    }

    private void Update()
    {
        healthbarController.SetHealth(health, maxHealth);
        attackTimer += Time.deltaTime;

        Collider2D[] playerUnitToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerUnitLayer);
        Collider2D[] baseToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, baseLayer);

        for (int i = 0; i < playerUnitToDamage.Length; i++)
        {
            StopAllCoroutines();
            StartCoroutine(StopToAttack());

            if (attackTimer >= attackRate)
            {
                playerUnitToDamage[i].GetComponent<PlayerManager>().health -= damage;

                attackTimer = resetAttackTimer;
            }
        }

        for (int i = 0; i < baseToDamage.Length; i++)
        {
            StopAllCoroutines();
            StartCoroutine(StopToAttack());

            if (attackTimer >= attackRate)
            {
                baseToDamage[i].GetComponent<BaseManager>().baseHealth -= damage;

                attackTimer = resetAttackTimer;
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
