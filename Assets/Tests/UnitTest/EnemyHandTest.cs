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
        var result = enemyHand.PickHand();
        List<Value.Hand> expectHand = new List<Value.Hand> { Value.Hand.Stone, Value.Hand.Scissors, Value.Hand.Paper };
        Assert.That(expectHand, Contains.Item(result) );
    }

    
}
