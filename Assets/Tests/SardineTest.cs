﻿using System.Collections;
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
        float x1, x2;
        bool useForce;

        useForce = false;
        x1 = rb.velocity.x;
        sardine.randomizeSpeed(useForce);
        x2 = rb.velocity.x;
        Assert.That(x1, Is.Not.EqualTo(x2));

        useForce = true;
        x1 = rb.velocity.x;
        sardine.randomizeSpeed(useForce);
        x2 = rb.velocity.x;
        Assert.That(x1, Is.EqualTo(x2));
    }
}