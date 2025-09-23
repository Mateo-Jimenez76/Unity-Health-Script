using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Health))]
public class HealthDisplayer : MonoBehaviour
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
        if (slider != null)
        {
            slider.value = CurrentHealth;
            AddListeners();
        }
    }

    private void OnValidate()
    {
        if (displayType == DisplayType.Slider && slider != null)
        {
            slider.maxValue = GetMaxHealth();
            slider.enabled = false; // Prevents an editor bug which sets the slider to 0
            slider.fillRect.GetComponent<Image>().color = fillColor;
            slider.GetComponentInChildren<Image>().color = backgroundColor;
            slider.enabled = true; // Re-enables the slider after setting the colors
            return;
        }
        if (displayType == DisplayType.Text)
        {
                switch (textStyle)
                {
                    case TextStyle.RawNumber:
                        textObject?.text = Health.CurrentHealth;
                        return;
                    case TextStyle.OutOf:
                        textObject?.text = health.CurrentHealth.ToString() + "/" + health.GetMaxHealth().ToString();
                        return;
                    case TextStyle.Percentage:
                        textObject?.text = (health.CurrentHealth / health.GetMaxHealth()).ToString();
                        return;
                    case TextStyle.Custom:
                        maxHealthTextObject?.text = health.GetMaxHealth();
                        currentHealthTextObject?.text = health.CurrentHealth();
                        return;
                    case default:
                        Debug.LogError("Invalid Text Style!");
                }
        }
    }

    private void UpdateHealthDisplay()
    {
        switch (displayType)
        {
            case DisplayType.Slider:
                slider.value = CurrentHealth;
                return;
            case DisplayType.Text:
                switch (textStyle)
                {
                    case TextStyle.RawNumber:
                        textObject?.text = Health.CurrentHealth;
                        return;
                    case TextStyle.OutOf:
                        textObject?.text = health.CurrentHealth.ToString() + "/" + health.GetMaxHealth().ToString();
                        return;
                    case TextStyle.Percentage:
                        textObject?.text = (health.CurrentHealth / health.GetMaxHealth()).ToString();
                        return;
                    case TextStyle.Custom:
                        maxHealthTextObject?.text = health.GetMaxHealth();
                        currentHealthTextObject?.text = health.CurrentHealth();
                        return;
                    case default:
                        Debug.LogError("Invalid Text Style!");
                }
                break;
            case default:
                Debug.LogError("Invalid Display Type!");
                return;
        }
    }

    public void AddListeners()
    {
        onDamage.AddListener(() => UpdateHealthDisplay());
        onHeal.AddListener(() => UpdateHealthDisplay());
    }

    internal enum DisplayType
    {
        Slider,
        Text,
    }

    internal enum TextStyle
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
