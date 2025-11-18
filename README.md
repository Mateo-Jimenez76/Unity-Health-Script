# Unity-Health-Script
![Health Inspector](https://github.com/user-attachments/assets/a9bbea22-ccdf-4fc2-8076-bb7f94dc24b6)

## How To Use
### Dealing Damage
To deal damage call the `Damage(int amount)` function. When damage is taken all events in the `OnDamage` UnityEvent will be invoked and if health is <= 0 then `OnDeath` will be invoked aswell. 
>[!IMPORTANT]
>OnDeath is invoked AFTER OnDamage and not instead of.

Implimentation in [Health.cs/Damage(int amount)](https://github.com/Mateo-Jimenez76/Unity-Health-Script/blob/a4a69911970ceddeb410e8de71320b76d3fd5b3a/Runtime/Health.cs#L39-L60)

### Healing
To heal call the `Heal(int amount)` function. This function will also invoke all events in the `OnHealth` UnityEvent.

Implimentation in [Health.cs/Heal(int amount)](https://github.com/Mateo-Jimenez76/Unity-Health-Script/blob/a4a69911970ceddeb410e8de71320b76d3fd5b3a/Runtime/Health.cs#L61-L85)
### Subscribing / Unsubscribing From Events
If you would like to subscribe to the events through scripts you can call `SubscribeTo...(UnityAction action)` followed by the name of the corresponding Unity Event. Ex: `SubscribeToOnDeath(UnityAction action)`. To unsubscribe is the same process but instead you call `UnsubscribeFrom...(UnityAction action)` with the UnityAction you wish to remove from the Event.

# Health Displayer

### Prerequisites
A Health script is required to be on the same object as the HealthDisplayer.
If one is not already on it then one will be created for you due to the effect of `[RequireComponent(typeof(Health))]`\

### Displaying As A Bar
<img width="499" height="140" alt="image" src="https://github.com/user-attachments/assets/50f02f87-70bc-48e8-8a6f-4ed7ad7a1035" />

### Prerequisites
A reference to a `Slider` is required

### Displaying As A Number
<img width="520" height="151" alt="image" src="https://github.com/user-attachments/assets/28df8acc-e54f-4dd7-aa5c-4596e72a1d04" />

### Prerequisites
A `TextMeshProUGUI` is required. While displaying as a number there are several formats to chose from which go as follows.

### Number Display Options

| Type  | Result |
| ------------- | ------------- |
| Out Of  | 50/100  |
| Percentage  | 50%  |
| Raw Number | 50 |
| Custom | This splits the max and current health values into two separate TextMeshProUGUI objects allowing for the user to manipulate placement and text styles however they please. |

# Additional Reading
https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html \
https://docs.unity3d.com/6000.2/Documentation/ScriptReference/UIElements.Slider.html \
https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Events.UnityAction.html \
https://docs.unity3d.com/6000.2/Documentation/ScriptReference/RequireComponent.html