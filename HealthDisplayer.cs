using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Health))]
public class HealthDisplayer : MonoBehavior
{
    [SerializeField] private DisplayType displayType;

    //show if display type is set to slider
    [Header("Slider Settings")]
    [SerializeField] private Slider slider;
    [SerializeField] private Color backgroundColor = Color.red;
    [SerializeField] private Color fillColor = Color.green;

    //Show text settings if display type is set to text
    [Header("Text Settings")]
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private TextStyle textStyle;
    //Show if text Style is set to custom
    [SerializeField] private TextMeshProUGUI maxHealthTextObject;
    [SerizalizeField] private TextMeshProUGUI currentHealthTextObject;

    private Health health; 
    private void Awake()
    {
        health = GetComponent<Health>();
    }

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
        if (displayType == DisplayType.Slider)
        {
            slider.value = CurrentHealth;
            return;
        }

        switch (textStyle)
        {
            case TextStyle.RawNumber:
                textObject.text = Health.CurrentHealth;
                break;
            case TextStyle.OutOf:
                textObject.text = health.CurrentHealth.ToString() + "/" + health.GetMaxHealth().ToString();
                break;
            case TextStyle.Percentage:
                textObject.text = (health.CurrentHealth / health.GetMaxHealth()).ToString();
                break;
            case TextStyle.Custom:
                if (maxHealthTextObject != null)
                {
                    maxHealthTextObject.text = health.GetMaxHealth();
                }
                
                if (currentHealthTextObject != null)
                {
                    currentHealthTextObject.text = health.CurrentHealth();
                }
                break;
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
        Text,
    }

    private enum TextStyle
    {
        //5
        RawNumber,
        // 5/10
        OutOf,
        //50%
        Percentage,
        Custom,
    }
}
