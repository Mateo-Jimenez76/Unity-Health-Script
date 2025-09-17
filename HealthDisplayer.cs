using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Script automatically sets up a slider to display the health of the object. Inherits from Health, no need to add Health component separately.
/// </summary>
[RequireComponent(typeof(Health))]
public class HealthDisplayer : MonoBehavior
{
    [SerializeField] private DisplayType displayType;
    
    [Header("Slider Settings")]
    [SerializeField] private Slider slider;
    [SerializeField] private Color backgroundColor = Color.red;
    [SerializeField] private Color fillColor = Color.green;


    private new void OnValidate()
    {
        base.OnValidate();
        if (slider != null)
        {
            slider.maxValue = GetMaxHealth();
            slider.enabled = false; // Prevents an editor bug which sets the slider to 0
            slider.fillRect.GetComponent<Image>().color = fillColor;
            slider.GetComponentInChildren<Image>().color = backgroundColor;
            slider.enabled = true; // Re-enables the slider after setting the colorss
        }
    }

    private new void Awake()
    {
        base.Awake();
        if (slider != null)
        {
            slider.value = CurrentHealth;
            AddListeners();
        }

    }

    private void UpdateHealthDisplay()
    {
        if(displayType == DisplayType.Slider)
        {
            slider.value = CurrentHealth;
        }

        if(displayType == DisplayType.Text)
        {
            
        }
    }

    public void AddListeners()
    {
        onDamage.AddListener(() => UpdateHealthDisplay());
        onHeal.AddListener(() => UpdateHealthDisplay());
    }

    private enum DisplayType
    {
        Slider,
        Text
    }
}
