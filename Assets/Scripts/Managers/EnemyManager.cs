using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
    public int speed;
    public int damage;
    public int attackRate;
    public float attackRange;
    public int health = 10;

    private float timeBetweenAttacks;
    private float maxTimeBetweenAttacks;

    public Transform attackPos;
    public LayerMask playerUnitLayer;

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x -= speed * Time.deltaTime;

        transform.position = pos;
    }

    private void Update()
    {
        if (timeBetweenAttacks >= attackRate)
        {
            Collider2D[] playerUnitToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerUnitLayer);
            for (int i = 0; i < playerUnitToDamage.Length; i++)
            {
                playerUnitToDamage[i].GetComponent<PlayerManager>().health -= damage;
            }
            timeBetweenAttacks = maxTimeBetweenAttacks;
        }
        else
        {
            timeBetweenAttacks += Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
