using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    public Slider slider;
    public Color Low;
    public Color high;

    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, high, slider.normalizedValue);
    }
}
