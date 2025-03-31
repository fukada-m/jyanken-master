using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class IntegStartButtonTest
{
    GameObject _menuButtons;
    GameObject _handButtons;
    GameObject _rankingButton;
    StartButton _startButton;
    Notify _notify;
    IObserver _observerText;
    TMP_Text _text;

    [SetUp]
    public void StartButtonSetUp()
    {
        _menuButtons = new GameObject("MenuButtons");
        _handButtons = new GameObject("HandButtons");
        _rankingButton = new GameObject("RankingButton");
        _startButton = new GameObject().AddComponent<StartButton>();
        _notify = new Notify();
        _observerText = new GameObject().AddComponent<ObserverText>();
        _text = new GameObject().AddComponent<TextMeshProUGUI>();
        // テストするためにfalseに設定
        _handButtons.SetActive(false);
        _observerText.Initialize(_text);
        _notify.AddObserver(_observerText);
        _startButton.Initialize(_menuButtons, _handButtons, _rankingButton, _observerText, _notify);
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
