using System.Collections;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class HealthDisplayerTester
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HealthDisplayerReferenceToHealth()
    {
        GameObject gameObject = new GameObject();
        Health health = gameObject.AddComponent<Health>();

        HealthDisplayer healthDisplayer = gameObject.AddComponent<HealthDisplayer>();
        yield return null;
        Assert.IsNotNull(healthDisplayer.Health);
    }
}