using UnityEngine;

public class SpawnMiniBoss : MonoBehaviour
{
    public GameObject miniboss;
    public GameObject enemySpawnPoint;
    private BaseManager baseManager;
    public bool hasMinibossSpawned = false;

    private void Start()
    {
        baseManager = GetComponent<BaseManager>();
    }
    private void Update()
    {
        if (baseManager.baseHealth <= 900 && hasMinibossSpawned == false)
        {
            Instantiate(miniboss, enemySpawnPoint.transform.position, Quaternion.identity);

            hasMinibossSpawned = true;
        }
    }
}
