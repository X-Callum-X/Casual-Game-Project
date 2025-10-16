using UnityEngine;
using TMPro;
public class InLevelCurrency : MonoBehaviour
{
    public TextMeshProUGUI currCurrencyText;
    public TextMeshProUGUI maxCurrencyText;

    public int currentCurrency;
    public int maxCurrency;
    public float increaseRate;
    public float increaseTimer;

    private void Update()
    {
        increaseTimer += Time.deltaTime;

        currCurrencyText.text = currentCurrency.ToString() + "/";
        maxCurrencyText.text = maxCurrency.ToString();

        if (increaseTimer >= increaseRate)
        {
            if (increaseTimer > 0.1)
            {
                increaseTimer = 0;
                currentCurrency += 1;

                if (currentCurrency > maxCurrency)
                {
                    currentCurrency = maxCurrency;
                }
            }
        }
    }

}
