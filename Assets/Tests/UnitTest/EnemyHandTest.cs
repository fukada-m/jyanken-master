using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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
        Assert.AreEqual(Value.Hand.Stone, result);
    }

    
}
