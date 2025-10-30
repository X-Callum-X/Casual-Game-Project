using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    public Slider slider;
    public void SetHealth(float health, float maxHealth)
    {
        slider.value = health / maxHealth;
    }
}
