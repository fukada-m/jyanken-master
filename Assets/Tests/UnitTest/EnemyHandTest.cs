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
    // A Test behaves as an ordinary method
    [Test]
    public void ChoseHand_enemyChoseHand()
    {
        Value.Hand result;
        var expectHand = new List<Value.Hand> { Value.Hand.Stone, Value.Hand.Scissors, Value.Hand.Paper };

        for (int i = 0; i < 10; i++)
        {
            result = enemyHand.PickHand();
            Assert.That(expectHand, Contains.Item(result));
            Debug.Log(result);
        }
    }

    
}
