# Unity-Health-Script
![Health Inspector](https://github.com/user-attachments/assets/a9bbea22-ccdf-4fc2-8076-bb7f94dc24b6)

# How To Use
### Dealing Damage
To deal damage call the `Damage(int amount)` function. When damage is taken all events in the `OnDamage` UnityEvent will be invoked and if health is <= 0 then `OnDeath` will be invoked aswell. 
>[!NOTE]
>OnDeath is invoked AFTER OnDamage and not instead of.

### Healing
To heal call the `Heal(int amount)` function. This function will invoke all events in the `OnHealth UnityEvent`.
### Subscribing / Unsubscribing From Events
If you would like to subscribe to the events through scripts you can call `SubscribeTo...(UnityAction action)` followed by the name of the corresponding Unity Event. Ex: `SubscribeToOnDeath(UnityAction action)`. To unsubscribe is the same process but instead you call `UnsubscribeFrom...(UnityAction action)` with the UnityAction you wish to remove from the Event.

# Health Displayer

# How To Use

### Prerequisites
A Health script is required to be on the same object as the HealthDisplayer.
If one is not already on it then one will be created for you due to the effect of `[RequireComponent(typeof(Health))]`

### Displaying as a bar
<img width="499" height="140" alt="image" src="https://github.com/user-attachments/assets/50f02f87-70bc-48e8-8a6f-4ed7ad7a1035" />

### Displaying as a number
A TextMeshProUGUI is required as a refenced to display the text. While displaying as a number there are several formats to chose from which go as follows \
Max Health = 100 \
Current Health  = 50 \
(Out Of) 50/100 \
(Percentage) 50% \
(Raw Number) 50 \
(Custom) This splits the max and current health values into two separate TextMeshProUGUI objects allowing for the user to manipulate placement and text styles however they please.
