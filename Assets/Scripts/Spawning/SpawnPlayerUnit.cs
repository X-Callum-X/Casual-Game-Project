using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayerUnit : MonoBehaviour
{
    public Button unitButton;
    public GameObject unitToSpawn;
    public GameObject unitSpawnPoint;
    public GameObject notEnoughCurrencyText;
    public int unitValue;
    public float unitCooldown;
    public bool isRecharging = false;
    private float cooldownTimer = 0;

    private InLevelCurrency currency;

    private void Start()
    {
        currency = FindAnyObjectByType<InLevelCurrency>();
    }

    private void Update()
    {
        if (isRecharging)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= unitCooldown)
            {
                unitButton.interactable = true;
                isRecharging = false;
                cooldownTimer = 0;
            }
        }
    }

    public void Spawn()
    {
        if (currency.currentCurrency >= unitValue )
        {
            Instantiate(unitToSpawn, unitSpawnPoint.transform.position, Quaternion.identity);
            currency.currentCurrency -= unitValue;
            isRecharging = true;
            unitButton.interactable = false;
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
