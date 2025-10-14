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
    }

    private void Start()
    {
        AddListeners();
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateHealthDisplayEditor()
    {
        switch (displayType)
        {
            case DisplayType.Slider:
                if(Slider == null) { return; }
                //Set the max value of the slider
                Slider.maxValue = 100;
                Slider.enabled = false; // Prevents an editor bug which sets the slider to 0
                                        //Set the fill color
                Slider.fillRect.GetComponent<Image>().color = FillColor;
                //Set the background color
                Slider.GetComponentInChildren<Image>().color = BackgroundColor;
                Slider.enabled = true; // Re-enables the slider after setting the colors
                return;
            case DisplayType.Text:
                switch (textStyle)
                {
                    case TextStyle.RawNumber:
                        if(TextObject == null) { return; }
                        TextObject.text = "50";
                        return;
                    case TextStyle.OutOf:
                        if (TextObject == null) { return; }
                        TextObject.text = 50 + "/" + 100;
                        return;
                    case TextStyle.Percentage:
                        if (TextObject == null) { return; }
                        TextObject.text = (50.0 / 100.0 * 100.0).ToString() + "%";
                        return;
                    case TextStyle.Custom:
                        if (MaxHealthTextObject == null) { return; }
                        if (CurrentHealthTextObject == null) { return; }
                        MaxHealthTextObject.text = "100";
                        CurrentHealthTextObject.text = "50";
                        return;
                }
                break;
        }
    }

    private void UpdateHealthDisplayRuntime()
    {
        switch (displayType)
        {
            case DisplayType.Slider:
                //Set the max value of the slider
                Slider.maxValue = health.CurrentHealth;
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
        health.SubscribeToOnDamage(() => UpdateHealthDisplayRuntime());
        health.SubscribeToOnHeal(() => UpdateHealthDisplayRuntime());
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
