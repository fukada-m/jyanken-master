using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections.Generic;

public class EnemyHandTest
{
    EnemyHand enemyHand;

    [SetUp]
    public void EnemyHandSetup()
    {
        enemyHand = new EnemyHand();
    }

    [Test]
    public void SetAndGetTest()
    {
        enemyHand.Current = Value.Hand.Stone;
        Assert.AreEqual(Value.Hand.Stone, enemyHand.Current);

    }
    // A Test behaves as an ordinary method
    [Test]
    public void ChoseHand_enemyChoseHand()
    {
        var expectHand = new List<Value.Hand> { Value.Hand.Stone, Value.Hand.Scissors, Value.Hand.Paper };

        for (int i = 0; i < 10; i++)
        {
            enemyHand.PickHand();
            Assert.That(expectHand, Contains.Item(enemyHand.Current));
            Debug.Log(enemyHand.Current);
        }
    }

    
}
