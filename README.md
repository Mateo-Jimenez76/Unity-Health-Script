# Unity-Health-Script
![Health Inspector](https://github.com/user-attachments/assets/a9bbea22-ccdf-4fc2-8076-bb7f94dc24b6)

# How To Use
### Dealing Damage
To deal damage call the `Damage(int amount)` function. When damage is taken all events in the `OnDamage` UnityEvent will be invoked and if health is <= 0 then `OnDeath` will be invoked aswell. 
>[!NOTE]
>OnDeath is invoked AFTER OnDamage and not instead of.

### Healing
To heal call the `Heal(int amount)` function. This function will invoke all events in the `OnHealh UnityEvent`.
### Subscribing / Unsubscribing From Events
If you would like to subscribe to the events through scripts you can call `SubscribeTo...(UnityAction action)` followed by the name of the corresponding Unity Event. Ex: `SubscribeToOnDeath(UnityAction action)`. To unsubscribe is the same process but instead you call `UnsubscribeFrom...(UnityAction action)` with the UnityAction you wish to remove from the Event.


