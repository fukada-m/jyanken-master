using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameStarterTest
{
    GameStarter gameStarter;
    GameObject handButtons;
    GameObject settingModal;
    GameObject ponBottun;
    StartButton startButton;
    Hand hand;
    ObserverText observerText;
    [SetUp]
    public void GameStarterSetUp()
    {
        handButtons = new GameObject("HandButtons");
        settingModal = new GameObject("SettingModal");
        ponBottun = new GameObject("PonButton");
        //startButton = new GameObject("StartButton").AddComponent<StartButton>();
        //hand = handButtons.AddComponent<Hand>();
        //observerText = new GameObject("ObserverText").AddComponent<ObserverText>();
        gameStarter = new GameObject().AddComponent<GameStarter>();

        typeof(GameStarter)
            .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, handButtons);
        typeof(GameStarter)
            .GetField("settingModal", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, settingModal);
        typeof(GameStarter)
            .GetField("ponButton", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameStarter, ponBottun);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Start_GameStarter()
    {
        yield return null;
        // �{�^������\���ɂȂ��Ă��邩
        Assert.IsFalse(handButtons.activeSelf);
        Assert.IsFalse(settingModal.activeSelf);
        Assert.IsFalse(ponBottun.activeSelf);


    }
}
