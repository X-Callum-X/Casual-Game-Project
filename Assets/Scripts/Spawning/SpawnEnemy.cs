using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject enemySpawnPoint;
    public float spawnCooldown, maxCooldown = 5f;

    private void Update()
    {
        spawnCooldown -= Time.deltaTime;
        Debug.Log(spawnCooldown);

        if (spawnCooldown <= 0)
        {
            int randomEnemy = Random.Range(0, enemies.Length);

            Instantiate(enemies[randomEnemy], enemySpawnPoint.transform.position, Quaternion.identity);

            spawnCooldown = maxCooldown;
        }
    }
}
