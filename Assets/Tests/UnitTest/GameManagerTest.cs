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
    GameObject settingModal;
    GameObject ponBottun;

    [SetUp]
    public void GameManagerTestSetUp()
    {
        handButtons = new GameObject("HandButtons");
        settingModal = new GameObject("SettingModal");
        ponBottun = new GameObject("PonButton");
            startButton = new GameObject("StartButton").AddComponent<StartButton>();
        hand = handButtons.AddComponent<Hand>();
        observerText = new GameObject("ObserverText").AddComponent<ObserverText>();
        gameManager = new GameObject().AddComponent<GameManager>();
    }

    [UnityTest]
    public IEnumerator Start_HideObject()
    {
        yield return null;
        Assert.IsFalse(handButtons.activeSelf);
        Assert.IsFalse(settingModal.activeSelf);
        Assert.IsFalse(ponBottun.activeSelf);
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
    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(startButton);
        Object.DestroyImmediate(handButtons);
        Object.DestroyImmediate(observerText);
        Object.DestroyImmediate(settingModal);
        Object.DestroyImmediate(ponBottun);
        Object.DestroyImmediate(gameManager);
    }
}
