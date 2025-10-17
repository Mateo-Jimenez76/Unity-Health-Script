using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    #region Serialized
    [Tooltip("The max health that the object will have.")]
    [field: SerializeField] public int MaxHealth { get; private set; } = 100;
    [Tooltip("The Unity event to be invoked when the health reaches or is below 0 after the OnDamage event is invoked.")]
    [SerializeField] private UnityEvent _onDeath;
    [Tooltip("The Unity event to be invoked when the object is damaged")]
    [SerializeField] private UnityEvent _onDamage;
    [Tooltip("The Unity event to be invoked when the object is healed")]
    [SerializeField] private UnityEvent _onHeal;
    [Tooltip("While true, prevents the loss of health.")]
    [SerializeField] private bool _invulnerable;
    #endregion Serialized
    public int CurrentHealth { get; private set; } = 0;

    #region Methods
    private void OnValidate()
    {
        if (MaxHealth < 0)
        {
            MaxHealth = 1;
            Debug.LogWarning("Max health cannot be 0 or less. Setting max health to 1.");
        }
    }

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    /// <summary>
    /// Subtracts the current health of the object by the provide amount.
    /// </summary>
    /// <param name="amount">The int value that is used to subtract from the current health of the object</param>
    public void Damage(int amount)
    {
        if(_invulnerable)
        {
            return;
        }
        CurrentHealth -= amount;
        _onDamage?.Invoke();
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            _onDeath?.Invoke();
        }
        return;
    }
    /// <summary>
    /// Does addition to the current health by the given value
    /// </summary>
    /// <param name="amount">The int value that is used to add to the current health of the object</param>
    public void Heal(int amount)
    {
        if (CurrentHealth + amount > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            return;
        }
        CurrentHealth += amount;
        _onHeal?.Invoke();
    }

    public void SubscribeToOnDeath(UnityAction action)
    {
        _onDeath.AddListener(action);
    }

    public void SubscribeToOnDamage(UnityAction action)
    {
        _onDamage.AddListener(action);
    }

    public void SubscribeToOnHeal(UnityAction action)
    {
        _onHeal.AddListener(action);
    }

    public void UnsubscribeFromOnDeath(UnityAction action)
    {
        _onDeath.RemoveListener(action);
    }

    public void UnsubscribeFromOnDamage(UnityAction action)
    {
        _onDamage.RemoveListener(action);
    }

    public void UnsubscribeFromOnHeal(UnityAction action)
    {
        _onHeal.RemoveListener(action);
    }
    #endregion Methods

}


