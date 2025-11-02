using UnityEngine;
using TMPro;
using System.Collections;
using System.Runtime.CompilerServices;
public class InLevelCurrency : MonoBehaviour
{
    public float incrementRate = 1f;
    public bool CooldownActive = false;
    public int currentCurrency;
    public int maxCurrency;
    private float realIncrementRate;

    public TMP_Text currCurrencyText;
    public TMP_Text maxCurrencyText;

    private void Start()
    {
        maxCurrencyText.text = maxCurrency.ToString();
    }

    private void Update()
    {
        currCurrencyText.text = currentCurrency.ToString() + "/";

        realIncrementRate = 1 / incrementRate;

        if (!CooldownActive && currentCurrency < maxCurrency)
        {
            StartCoroutine(Increment());
        }

        if (currentCurrency >= maxCurrency)
        {
            currentCurrency = maxCurrency;
        }
    }

    public IEnumerator Increment()
    {
        CooldownActive = true;
        yield return new WaitForSeconds(realIncrementRate);
        currentCurrency += 1;
        CooldownActive = false;
    }
}
