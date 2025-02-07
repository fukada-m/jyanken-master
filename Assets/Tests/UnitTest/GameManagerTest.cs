using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTest
{
    GameManager gameManager;
    [SetUp]
    public void GameManagerTestSetUp()
    {
        gameManager = new GameObject().AddComponent<GameManager>();
        var hand = new GameObject().AddComponent<Hand>();
        typeof(GameManager)
            .GetField("hand", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameManager, hand);
    }

    [Test]
    public void ConvertSignToJapanese_Convert()
    {
        var result = gameManager.ConvertSignToJapanese(GameManager.Sign.Stone);
        Assert.AreEqual("グー", result);

        result = gameManager.ConvertSignToJapanese(GameManager.Sign.Scissors);
        Assert.AreEqual("チョキ", result);

        result = gameManager.ConvertSignToJapanese(GameManager.Sign.Paper);
        Assert.AreEqual("パー", result);
    }

}
