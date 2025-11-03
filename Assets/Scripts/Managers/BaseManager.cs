using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public float baseHealth = 10;
    public float maxBaseHealth = 10;

    public GameObject youWinScreen;
    public GameObject youLoseScreen;
    public GameObject LevelUI;
    private HealthbarController healthbarController;
    private SpawnEnemy spawnEnemy;

    private void Start()
    {
        healthbarController = GetComponentInChildren<HealthbarController>();
        spawnEnemy = GetComponent<SpawnEnemy>();
    }

    private void Update()
    {
        healthbarController.SetHealth(baseHealth, maxBaseHealth);

        if (baseHealth <= 0)
        {
            baseHealth = 0;
            LevelUI.SetActive(false);

            if (this.gameObject.CompareTag("Enemy"))
            {
                youWinScreen.SetActive(true);
                spawnEnemy.enabled = false;
            }
            else if (this.gameObject.CompareTag("Player Unit"))
            {
                youLoseScreen.SetActive(true);
            }
        }
    }
}
