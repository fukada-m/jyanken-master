using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class IntegHandButtonTest
{
    GameObject _ponButton;
    HandButtons _handButtons;
    Notify _notify;
    PlayerHand _playerHand;
    IObserver _observerText;
    TMP_Text _text;

    [SetUp]
    public void HandButtonsTestSetUp()
    {
        _handButtons = new GameObject().AddComponent<HandButtons>();
        _ponButton = new GameObject("PonButton");
        _observerText = new GameObject().AddComponent<ObserverText>();
        _text = new GameObject().AddComponent<TextMeshProUGUI>();
        _playerHand = new PlayerHand();
        _notify = new Notify();
        _observerText.Initialize(_text);
        _notify.AddObserver(_observerText);
        _handButtons.Initialize(_ponButton, _observerText, _notify, _playerHand);
    }

    [Test]
    public void OnClickStoneButton_SetsHandToStone()
    {
        _handButtons.OnClickStoneButton();
        Assert.AreEqual("あなたはグーを選んでいます", _observerText.GetText());
        Assert.IsTrue(_ponButton);
    }

    [Test]
    public void OnClickPaperButton_SetsHandToPaper()
    {
        _handButtons.OnClickPaperButton();
        Assert.AreEqual("あなたはパーを選んでいます", _observerText.GetText());
        Assert.IsTrue(_ponButton);
    }

    [Test]
    public void OnClickScissorsButton_SetsHandToScissors()
    {
        _handButtons.OnClickScissorsButton();
        Assert.AreEqual("あなたはチョキを選んでいます", _observerText.GetText());
        Assert.IsTrue(_ponButton);
    }

}
