using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    #region Serialized
    [Tooltip("The max health that the object will have.")]
    [SerializeField] private int maxHealth;
    [Tooltip("The Unity event to be invoked when the health reaches or is below 0")]
    [SerializeField] private UnityEvent onDeath;
    [Tooltip("The Unity event to be invoked when the object is damaged")]
    [SerializeField] private UnityEvent onDamage;
    #endregion Serialized
    public int CurrentHealth { get; private set; }

    #region Methods

    //Awake is called the frame the gameObject becomes active
    public void Awake()
    {
        CurrentHealth = maxHealth;
    }

    /// <summary>
    /// Subtracts the current health by the given value
    /// </summary>
    /// <param name="amount"></param>
    public void Damage(int amount)
    {
        CurrentHealth -= amount;
        onDamage?.Invoke();
        if(CurrentHealth <= 0)
        {
            onDeath?.Invoke();
        }
        return;
    }

    public void Heal(int amount)
    {
        if (CurrentHealth + amount > maxHealth)
        {
            CurrentHealth = maxHealth;
            return;
        }
        CurrentHealth += amount;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    #endregion Methods
}
