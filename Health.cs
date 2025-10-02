using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    #region Serialized
    [Tooltip("The max health that the object will have.")]
    [field: SerializeField] public int MaxHealth { get; private set; } = 100;
    [Tooltip("The Unity event to be invoked when the health reaches or is below 0 after the damage function has been called.")]
    [SerializeField] private UnityEvent onDeath;
    [Tooltip("The Unity event to be invoked when the object is damaged")]
    [SerializeField] private UnityEvent onDamage;
    [Tooltip("The Unity event to be invoked when the object is healed")]
    [SerializeField] private UnityEvent onHeal;
    [Tooltip("While true, prevents the loss of health.")]
    [SerializeField] private bool invulnerable;
    #endregion Serialized
    public int CurrentHealth { get; private set; }

    #region Methods
    protected void OnValidate()
    {
        if (MaxHealth < 0)
        {
            MaxHealth = 1;
            Debug.LogWarning("Max health cannot be 0 or less. Setting max health to 1.");
        }
    }

    protected void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    /// <summary>
    /// Subtracts the current health of the object by the provide amount.
    /// </summary>
    /// <param name="amount">The int value that is used to subtract from the current health of the object</param>
    public void Damage(int amount)
    {
        if(invulnerable)
        {
            return;
        }
        CurrentHealth -= amount;
        onDamage?.Invoke();
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            onDeath?.Invoke();
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
        onHeal?.Invoke();
    }

    public void SubscribeToOnDeath(UnityAction action)
    {
        onDeath.AddListener(action);
    }

    public void SubscribeToOnDamage(UnityAction action)
    {
        onDamage.AddListener(action);
    }

    public void SubscribeToOnHeal(UnityAction action)
    {
        onHeal.AddListener(action);
    }

    public void UnsubscribeFromOnDeath(UnityAction action)
    {
        onDeath.RemoveListener(action);
    }

    public void UnsubscribeFromOnDamage(UnityAction action)
    {
        onDamage.RemoveListener(action);
    }

    public void UnsubscribeFromOnHeal(UnityAction action)
    {
        onHeal.RemoveListener(action);
    }
    #endregion Methods

}


