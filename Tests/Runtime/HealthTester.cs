using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class HealthTester
{
    private List<GameObject> objectsToTearDown = new();
    [UnityTearDown]
    public IEnumerator TearDown()
    {
        for (int i = 0; i < objectsToTearDown.Count; i++)
        {
            GameObject obj = objectsToTearDown[i];
            objectsToTearDown.RemoveAt(i);
            Object.Destroy(obj);
            yield return null;
        }
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    [TestCase(1, ExpectedResult = true)]
    [TestCase(50, ExpectedResult = true)]
    [TestCase(75, ExpectedResult = true)]
    public IEnumerator Health_Damage_True(int input)
    {
        GameObject gameObject = new GameObject();
        Health health = gameObject.AddComponent<Health>();
        objectsToTearDown.Add(gameObject);

        health.Damage(input);
        yield return null;
        Assert.AreEqual(health.MaxHealth - input, health.CurrentHealth);
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    [TestCase(ExpectedResult = true)]
    public IEnumerator Health_Damage_TrueDeath()
    {
        GameObject gameObject = new GameObject();
        Health health = gameObject.AddComponent<Health>();
        objectsToTearDown.Add(gameObject);


        health.Damage(health.MaxHealth);
        yield return null;
        Assert.AreEqual(0, health.CurrentHealth);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    [TestCase(ExpectedResult = false)]
    public IEnumerator Health_Damage_NegativeInput()
    {
        GameObject gameObject = new GameObject();
        Health health = gameObject.AddComponent<Health>();
        objectsToTearDown.Add(gameObject);

        health.Damage(-100);
        LogAssert.Expect(LogType.Warning, "Damage amount must be greater than 0!");
        yield return null;
        Assert.AreEqual(health.MaxHealth, health.CurrentHealth);

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    [TestCase(1, ExpectedResult = false)]
    [TestCase(25, ExpectedResult = false)]
    [TestCase(50, ExpectedResult = false)]
    public IEnumerator Health_Heal_FalseAtFullHealth(int input)
    {
        GameObject gameObject = new GameObject();
        Health health = gameObject.AddComponent<Health>();
        objectsToTearDown.Add(gameObject);

        health.Heal(input);
        yield return null;
        Assert.AreEqual(health.MaxHealth, health.CurrentHealth);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    [TestCase(1, ExpectedResult = false)]
    [TestCase(25, ExpectedResult = false)]
    [TestCase(50, ExpectedResult = false)]
    public IEnumerator Health_Heal_True(int input)
    {
        GameObject gameObject = new GameObject();
        Health health = gameObject.AddComponent<Health>();
        objectsToTearDown.Add(gameObject);

        health.Damage(input);
        yield return null;
        Assert.IsTrue(health.Heal(input));
        yield return null;
        Assert.AreEqual(health.MaxHealth, health.CurrentHealth);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    [TestCase(ExpectedResult = false)]
    public IEnumerator Health_Heal_NegativeInput()
    {
        GameObject gameObject = new GameObject();
        Health health = gameObject.AddComponent<Health>();
        objectsToTearDown.Add(gameObject);

        health.Heal(-1);
        yield return null;
        Assert.AreEqual(health.MaxHealth,health.CurrentHealth);
        LogAssert.Expect(LogType.Warning, "Heal amount must be greater than 0!");
    }
}

