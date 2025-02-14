using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class IntegStartButtonTest
{
    GameObject _menuButtons;
    GameObject _handButtons;
    StartButton _startButton;
    Notify _start;
    IObserver _observerText;
    TMP_Text _text;

    [SetUp]
    public void StartButtonSetUp()
    {
        _menuButtons = new GameObject("MenuButtons");
        _handButtons = new GameObject("HandButtons");
        _startButton = new GameObject().AddComponent<StartButton>();
        _start = new Start();
        _observerText = new GameObject().AddComponent<ObserverText>();
        _text = new GameObject().AddComponent<TextMeshProUGUI>();
        // テストするためにfalseに設定
        _handButtons.SetActive(false);
        _observerText.Initialize(_text);
        _start.AddObserver(_observerText);
        _startButton.Initialize(_menuButtons, _handButtons, _start);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void OnClickButton_StartJyanken()
    {
        _startButton.OnClickButton();

        Assert.IsTrue(_handButtons.activeSelf);
        Assert.IsFalse(_menuButtons.activeSelf);
        Assert.AreEqual("何の手を出すか決めてください", _observerText.GetText());
    }

}
