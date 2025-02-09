using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTest
{
    GameManager gameManager;
    StartButton startButton;
    Hand hand;
    ObserverText observerText;
    GameObject handButtons;
    GameObject setting;
    GameObject ponBottun;

    [SetUp]
    public void GameManagerTestSetUp()
    {
        startButton = new GameObject("StartButton").AddComponent<StartButton>();
        handButtons = new GameObject("HandButtons");
        hand = handButtons.AddComponent<Hand>();
        observerText = new GameObject("ObserverText").AddComponent<ObserverText>();
        setting = new GameObject("Setting");
        ponBottun = new GameObject("PonButton");
        gameManager = new GameObject().AddComponent<GameManager>();
    }

    [UnityTest]
    public IEnumerator Start_HideObject()
    {
        yield return null;
        Assert.IsFalse(handButtons.activeSelf);
        Assert.IsFalse(setting.activeSelf);
        Assert.IsFalse(ponBottun.activeSelf);
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
    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(startButton);
        Object.DestroyImmediate(handButtons);
        Object.DestroyImmediate(observerText);
        Object.DestroyImmediate(setting);
        Object.DestroyImmediate(ponBottun);
        Object.DestroyImmediate(gameManager);
    }
}
