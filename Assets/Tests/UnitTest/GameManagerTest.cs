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
    }

    [Test]

    public void ConvertSignToJapanese_Convert()
    {
        var result = gameManager.ConvertSignToJapanese(GameManager.Sign.Stone);
        Assert.AreEqual("�O�[", result);

        result = gameManager.ConvertSignToJapanese(GameManager.Sign.Scissors);
        Assert.AreEqual("�`���L", result);

        result = gameManager.ConvertSignToJapanese(GameManager.Sign.Paper);
        Assert.AreEqual("�p�[", result);
    }

}
