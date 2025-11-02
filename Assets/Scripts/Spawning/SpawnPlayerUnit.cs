using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnPlayerUnit : MonoBehaviour
{
    public TMP_Text unitPriceText;
    public Slider cooldownSlider;
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
        cooldownSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        cooldownSlider.value = cooldownTimer;

        if (isRecharging)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= unitCooldown)
            {
                unitButton.interactable = true;
                isRecharging = false;
                cooldownTimer = 0;
                unitPriceText.gameObject.SetActive(true);
                cooldownSlider.gameObject.SetActive(false);
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
            unitPriceText.gameObject.SetActive(false);
            cooldownSlider.gameObject.SetActive(true);
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
