using System.Collections;
using UnityEngine;

public class SpawnPlayerUnit : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject unitSpawnPoint;
    public GameObject notEnoughCurrencyText;
    public int unitValue;

    private InLevelCurrency currency;

    private void Start()
    {
        currency = FindAnyObjectByType<InLevelCurrency>();
    }

    public void Spawn()
    {
        if (currency.currentCurrency >= unitValue)
        {
            Instantiate(unitToSpawn, unitSpawnPoint.transform.position, Quaternion.identity);
            currency.currentCurrency -= unitValue;
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(NotEnoughCurrency());
        }
    }

    private IEnumerator NotEnoughCurrency()
    {
        notEnoughCurrencyText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        notEnoughCurrencyText.SetActive(false);
    }
}
