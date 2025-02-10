using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class GameStarterTest
{
    GameStarter gameStarter;
    GameObject handButtons;
    GameObject settingModal;
    GameObject ponBottun;
    GameObject observerTextObject;
    Mock<StartButton> mockStartButton;
    Mock<IHand> mockHand;
    Mock<IObserver> mockObserverText;

    [SetUp]
    public void GameStarterSetUp()
    {
        handButtons = new GameObject("HandButtons");
        settingModal = new GameObject("SettingModal");
        ponBottun = new GameObject("PonButton");
        observerTextObject = new GameObject("ObserverText");
        mockStartButton = new Mock<StartButton>();
        mockHand = new Mock<IHand>();
        mockObserverText = new Mock<IObserver>();
        gameStarter = new GameObject().AddComponent<GameStarter>();

        gameStarter.TestInitialize(
            handButtons, 
            settingModal, 
            ponBottun,
            observerTextObject,
            //mockStartButton.Object,
            mockHand.Object,
            mockObserverText.Object
         );
        typeof(GameStarter)
            .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, handButtons);
        typeof(GameStarter)
            .GetField("settingModal", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, settingModal);
        typeof(GameStarter)
            .GetField("ponButton", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, ponBottun);
        typeof(GameStarter)
            .GetField("observerTextObject", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, observerTextObject);
        typeof(GameStarter)
            .GetField("startButton", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, mockStartButton.Object);
        typeof(GameStarter)
            .GetField("hand", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, mockHand.Object);
        typeof(GameStarter)
            .GetField("observerText", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, mockObserverText.Object);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Start_GameStarter()
    {
        yield return null;
        // ƒ{ƒ^ƒ“‚ª”ñ•\Ž¦‚É‚È‚Á‚Ä‚¢‚é‚©
        Assert.IsFalse(handButtons.activeSelf);
        Assert.IsFalse(settingModal.activeSelf);
        Assert.IsFalse(ponBottun.activeSelf);
        // AddObserver‚ªŒÄ‚×‚é‚©
        mockHand.Verify(m => m.AddObserver(mockObserverText.Object), Times.Once);
        mockStartButton.Verify(m => m.AddObserver(mockObserverText.Object), Times.Once());


    }
}
