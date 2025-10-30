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
        currCurrencyText.text = (currentCurrency.ToString() + "/");
        CooldownActive = false;
    }

    //public TextMeshProUGUI currCurrencyText;
    //public TextMeshProUGUI maxCurrencyText;

    //public int currentCurrency;
    //public int maxCurrency;
    //public float increaseRate;
    //public float increaseTimer;

    //private void Update()
    //{
    //    increaseTimer += Time.deltaTime;

    //    currCurrencyText.text = currentCurrency.ToString() + "/";
    //    maxCurrencyText.text = maxCurrency.ToString();

    //    if (increaseTimer >= increaseRate)
    //    {
    //        if (increaseTimer > 0.1)
    //        {
    //            increaseTimer = 0;
    //            currentCurrency += 1;

    //            if (currentCurrency > maxCurrency)
    //            {
    //                currentCurrency = maxCurrency;
    //            }
    //        }
    //    }
    //}

}
