using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StartButtonTest
{
    GameObject menuButtons;
    GameObject handButtons;
    StartButton startButton;

    [SetUp]
    public void StartStateSetUp()
    {
        handButtons = new GameObject("HandButtons");
        startButton = new GameObject("Startbutton").AddComponent<StartButton>();
        menuButtons = new GameObject("MenuButtons");
        // テストするためにfalseに設定
        handButtons.SetActive(false);

        // コンポジションを設定
        typeof(StartButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(startButton, menuButtons);
        typeof(StartButton)
            .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(startButton, handButtons);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void DispButton_StartAndOption()
    {
        startButton.onClick();
        Assert.IsTrue(handButtons.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
    }
}
