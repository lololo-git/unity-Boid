using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class SardineTest
{
    private Sardine prefab = default;
    private Sardine sardine = default;

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
        sardine = GameObject.Instantiate(prefab);
    }

    [TearDown]
    public void TearDown()
    {
        Debug.Log("TearDown");
        GameObject.DestroyImmediate(sardine);
    }

    [Test]
    public void RandomizedSpeedTest()
    {
        Rigidbody2D rb = sardine.GetComponent<Rigidbody2D>();

        var x1 = rb.velocity.x;
        sardine.randomizeSpeed();
        var x2 = rb.velocity.x;

        Assert.That(x1, Is.Not.EqualTo(x2));
    }
}