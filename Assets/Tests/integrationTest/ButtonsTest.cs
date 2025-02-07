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
    GameObject setting;



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
        setting = new GameObject("Setting");

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
            .SetValue(optionButton, setting);
        typeof(OptionButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(optionButton, menuButtons);
        typeof(ReturnButton)
            .GetField("setting", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(returnButton, setting);
        typeof(ReturnButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(returnButton, menuButtons);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void onClickStartButtons()
    {
        optionButton.onClickButton();
        Assert.IsTrue(setting.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
        returnButton.onClickButton();
        Assert.IsTrue(menuButtons.activeSelf);
        Assert.IsFalse(setting.activeSelf);
        startButton.onClick();
        Assert.AreEqual(observerText.GetText(), "âΩÇÃéËÇèoÇ∑Ç©åàÇﬂÇƒÇ≠ÇæÇ≥Ç¢");

    }

}
