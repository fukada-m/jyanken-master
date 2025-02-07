using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class ButtonsTest
{
    GameManager gameManager;
    StartButton startButton;
    Hand hand;
    ObserverText observerText;


    [SetUp]
    public void ButtonsTestSetUp()
    {
        var gm = new GameObject("GameManager");
        var sb = new GameObject("StartButton");
        var hb = new GameObject("HandButtons");
        var ot = new GameObject("ObserverText");
        var mb = new GameObject("MenuButtons");
        gameManager = gm.AddComponent<GameManager>();
        startButton = sb.AddComponent<StartButton>();
        hand = hb.AddComponent<Hand>();
        observerText = ot.AddComponent<ObserverText>();
        hand.AddObserver(observerText);
        startButton.AddObserver(observerText);
        var text = ot.AddComponent<TextMeshProUGUI>();

        typeof(ObserverText)
            .GetField("text", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(observerText, text);
        typeof(GameManager)
            .GetField("hand", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(gameManager, hand);
        typeof(StartButton)
             .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
             .SetValue(startButton, mb);
        typeof(StartButton)
            .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(startButton, hb);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void onClickStartButton_JyankenStart()
    {
        startButton.onClick();
        Assert.AreEqual(observerText.GetText(), "âΩÇÃéËÇèoÇ∑Ç©åàÇﬂÇƒÇ≠ÇæÇ≥Ç¢");

    }
    public void onClickOptionButton_ShowSetting()
    {

    }
    public void onClickOptionReturnButton_CloseSetting()
    {

    }
}
