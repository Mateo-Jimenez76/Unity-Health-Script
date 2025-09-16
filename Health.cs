using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    #region Serialized
    [Tooltip("The max health that the object will have.")]
    [SerializeField] protected int maxHealth = 100;
    [Tooltip("The Unity event to be invoked when the health reaches or is below 0 after the damage function has been called.")]
    [SerializeField] protected UnityEvent onDeath;
    [Tooltip("The Unity event to be invoked when the object is damaged")]
    [SerializeField] protected UnityEvent onDamage;
    [Tooltip("The Unity event to be invoked when the object is healed")]
    [SerializeField] protected UnityEvent onHeal;
    #endregion Serialized
    public int CurrentHealth { get; private set; }

    #region Methods
    protected void OnValidate()
    {
        if (maxHealth < 0)
        {
            maxHealth = 1;
            Debug.LogWarning("Max health cannot be 0 or less. Setting max health to 1.");
        }
    }

    protected void Awake()
    {
        CurrentHealth = maxHealth;
    }

    /// <summary>
    /// Subtracts the current health of the object by the provide amount.
    /// </summary>
    /// <param name="amount">The int value that is used to subtract from the current health of the object</param>
    public void Damage(int amount)
    {
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
        if (CurrentHealth + amount > maxHealth)
        {
            CurrentHealth = maxHealth;
            return;
        }
        CurrentHealth += amount;
        onHeal?.Invoke();
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    #endregion Methods

}
