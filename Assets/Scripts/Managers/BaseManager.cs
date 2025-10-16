using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public int baseHealth = 10;

    public GameObject youWinScreen;
    public GameObject youLoseScreen;
    public GameObject LevelUI;

    private void Update()
    {
        if (baseHealth <= 0)
        {
            baseHealth = 0;
            LevelUI.SetActive(false);

            if (this.gameObject.CompareTag("Enemy"))
            {
                youWinScreen.SetActive(true);
            }
            else if (this.gameObject.CompareTag("Player Unit"))
            {
                youLoseScreen.SetActive(true);
            }
        }
    }
}
