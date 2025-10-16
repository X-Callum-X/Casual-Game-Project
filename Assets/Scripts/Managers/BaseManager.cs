using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public int baseHealth = 10;

    public GameObject youWinScreen;
    public GameObject youLoseScreen;

    private void Update()
    {
        if (baseHealth <= 0)
        {
            baseHealth = 0;

            if (this.gameObject.CompareTag("Enemy Base"))
            {
                youLoseScreen.SetActive(true);
            }
            else if (this.gameObject.CompareTag("Player Base"))
            {
                youWinScreen.SetActive(true);
            }
        }
    }
}
