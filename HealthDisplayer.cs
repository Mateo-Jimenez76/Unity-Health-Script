using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script automatically sets up a slider to display the health of the object. Inherits from Health, no need to add Health component separately.
/// </summary>
[RequireComponent(typeof(Health))]
public class HealthDisplayer : Health
{

    [Header("Slider Settings")]
    [SerializeField] private Slider slider;
    [SerializeField] private Color backgroundColor = Color.red;
    [SerializeField] private Color fillColor = Color.green;


    private void OnValidate()
    {
        if (slider != null)
        {
            slider.maxValue = GetMaxHealth();
            slider.enabled = false; // Prevents an editor bug which sets the slider to 0
            slider.fillRect.GetComponent<Image>().color = fillColor;
            slider.GetComponentInChildren<Image>().color = backgroundColor;
            slider.enabled = true; // Re-enables the slider after setting the colors
        }
    }

    private new void Awake()
    {
        base.Awake();
        if (slider != null)
        {
            slider.value = CurrentHealth;
        }
        onDamage.AddListener(() => UpdateHealthDisplay());
        onHeal.AddListener(() => UpdateHealthDisplay());
    }

    private void UpdateHealthDisplay()
    {
        if (slider != null)
        {
            slider.value = CurrentHealth;
        }
    }
}
