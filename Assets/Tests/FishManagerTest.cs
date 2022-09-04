using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FishManagerTest
{
    private GameObject gameObject = default;
    private FishManager fishManager = default;

    private Sardine prefab = default;
    private Sardine sardine0 = default;
    private Sardine sardine1 = default;
    private Sardine sardine2 = default;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Debug.Log("OnetimeSetUp");
        prefab = Resources.Load<Sardine>("Prefabs/sardinePrefab");
    }

    [SetUp]
    public void Setup()
    {
        Debug.Log("SetUp");

        gameObject = new GameObject();
        fishManager = gameObject.AddComponent<FishManager>();

        sardine0 = GameObject.Instantiate(prefab);
        sardine1 = GameObject.Instantiate(prefab);
        sardine2 = GameObject.Instantiate(prefab);
    }

    [TearDown]
    public void TearDown()
    {
        Debug.Log("TearDown");
        GameObject.DestroyImmediate(gameObject);
        GameObject.DestroyImmediate(sardine0);
        GameObject.DestroyImmediate(sardine1);
        GameObject.DestroyImmediate(sardine2);
    }

    // Todo write SpawnTest()
    // Todo write GetSardineByRangeTest()

    [Test]
    public void GetDistanceTest()
    {
        float expect, actual;

        expect = 0;
        actual = fishManager.GetDistance(sardine0, sardine0);
        LogAssert.Expect(LogType.Error, "Distance between same Object");
        Assert.That(actual, Is.EqualTo(expect));

        expect = Mathf.Sqrt(3 * 3 + 5 * 5);
        sardine0.transform.position = new Vector2(3, 0);
        sardine1.transform.position = new Vector2(0, 5);
        actual = fishManager.GetDistance(sardine0, sardine1);
        Assert.That(actual, Is.EqualTo(expect));

        // Cache check
        expect = Mathf.Sqrt(3 * 3 + 5 * 5);
        sardine0.transform.position = new Vector2(5, 0);
        sardine1.transform.position = new Vector2(0, 7);
        actual = fishManager.GetDistance(sardine0, sardine1);
        Assert.That(actual, Is.EqualTo(expect));
    }
}