using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Health))]
public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] private DisplayType displayType;

    [SerializeField] private Slider Slider;
    [SerializeField] private Color BackgroundColor = Color.red;
    [SerializeField] private Color FillColor = Color.green;

    [SerializeField] private TextMeshProUGUI TextObject;
    [SerializeField] private TextStyle textStyle;

    [SerializeField] public TextMeshProUGUI MaxHealthTextObject;
    [SerializeField] public TextMeshProUGUI CurrentHealthTextObject;

    private Health health;
    private void Awake()
    {
        health = GetComponent<Health>();

        if (Slider != null)
        {
            Slider.value = health.CurrentHealth;
        }

        AddListeners();
    }

    private void OnValidate()
    {
        if (displayType == DisplayType.Slider)
        {
            if(Slider == null)
            {
                return;
            }
            //Set the max value of the slider
            Slider.maxValue = health.MaxHealth;
            Slider.enabled = false; // Prevents an editor bug which sets the slider to 0
            //Set the fill color
            Slider.fillRect.GetComponent<Image>().color = FillColor;
            //Set the background color
            Slider.GetComponentInChildren<Image>().color = BackgroundColor;
            Slider.enabled = true; // Re-enables the slider after setting the colors
            return;
        }
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        switch (displayType)
        {
            case DisplayType.Slider:
                Slider.value = health.CurrentHealth;
                return;
            case DisplayType.Text:
                switch (textStyle)
                {
                    case TextStyle.RawNumber:
                        TextObject.text = health.CurrentHealth.ToString();
                        return;
                    case TextStyle.OutOf:
                        TextObject.text = health.CurrentHealth.ToString() + "/" + health.MaxHealth.ToString();
                        return;
                    case TextStyle.Percentage:
                        TextObject.text = (health.CurrentHealth / health.MaxHealth).ToString() + "%";
                        return;
                    case TextStyle.Custom:
                        MaxHealthTextObject.text = health.MaxHealth.ToString();
                        CurrentHealthTextObject.text = health.CurrentHealth.ToString();
                        return;
                }
                break;
        }
    }

    private void AddListeners()
    {
        health.SubscribeToOnDamage(() => UpdateHealthDisplay());
        health.SubscribeToOnHeal(() => UpdateHealthDisplay());
    }

    public enum DisplayType
    {
        Slider,
        Text,
    }

    public enum TextStyle
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
