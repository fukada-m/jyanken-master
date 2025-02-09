using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class ButtonsTest
{
    GameManager gameManager;
    StartButton startButton;
    OptionButton optionButton;
    ReturnButton returnButton;
    Hand hand;
    ObserverText observerText;
    GameObject menuButtons;
    GameObject settingModal;



    [SetUp]
    public void ButtonsTestSetUp()
    {
        var gm = new GameObject("GameManager");
        var sb = new GameObject("StartButton");
        var hb = new GameObject("HandButtons");
        menuButtons = new GameObject("MenuButtons");
        var ob = new GameObject("OptionButton");
        var rb = new GameObject("ReturnButton");
        var ot = new GameObject("ObserverText");
        settingModal = new GameObject("SettingModal");

        gameManager = gm.AddComponent<GameManager>();
        startButton = sb.AddComponent<StartButton>();
        hand = hb.AddComponent<Hand>();
        optionButton = ob.AddComponent<OptionButton>();
        returnButton = rb.AddComponent<ReturnButton>();
        observerText = ot.AddComponent<ObserverText>();
        hand.AddObserver(observerText);
        startButton.AddObserver(observerText);
        var text = ot.AddComponent<TextMeshProUGUI>();
        hb.SetActive(false);
        menuButtons.SetActive(false);

        typeof(GameManager)
            .GetField("hand", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameManager, hand);
        typeof(StartButton)
             .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
             .SetValue(startButton, menuButtons);
        typeof(StartButton)
            .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(startButton, hb);
        typeof(ObserverText)
            .GetField("text", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(observerText, text);
        typeof(ObserverText)
            .GetField("gameManager", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(observerText, gameManager);
        typeof(OptionButton)
            .GetField("setting", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(optionButton, settingModal);
        typeof(OptionButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(optionButton, menuButtons);
        typeof(ReturnButton)
            .GetField("setting", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(returnButton, settingModal);
        typeof(ReturnButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(returnButton, menuButtons);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void onClickStartButtons()
    {
        optionButton.OnClickButton();
        Assert.IsTrue(settingModal.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
        returnButton.OnClickButton();
        Assert.IsTrue(menuButtons.activeSelf);
        Assert.IsFalse(settingModal.activeSelf);
        startButton.OnClickButton();
        Assert.AreEqual(observerText.GetText(), "âΩÇÃéËÇèoÇ∑Ç©åàÇﬂÇƒÇ≠ÇæÇ≥Ç¢");

    }

}
