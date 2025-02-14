using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

public class IntegHandButtonTest
{
    HandButtons _handButtons;
    Hand _hand;
    ISign _sign;
    IObserver _observerText;
    TMP_Text _text;

    [SetUp]
    public void HandButtonsTestSetUp()
    {
        _handButtons = new GameObject().AddComponent<HandButtons>();
        _observerText = new GameObject().AddComponent<ObserverText>();
        _text = new GameObject().AddComponent<TextMeshProUGUI>();
        _sign = new Sign();
        _hand = new Hand(_sign);
        _observerText.Initialize(_text);
        _hand.AddObserver(_observerText);
        _handButtons.Initialize(_hand);
    }

    [Test]
    public void OnClickStoneButton_SetsHandToStone()
    {
        _handButtons.OnClickStoneButton();
        Assert.AreEqual("あなたはグーを選んでいます", _observerText.GetText());
    }

    [Test]
    public void OnClickPaperButton_SetsHandToPaper()
    {
        _handButtons.OnClickPaperButton();
        Assert.AreEqual("あなたはパーを選んでいます", _observerText.GetText());
    }

    [Test]
    public void OnClickScissorsButton_SetsHandToScissors()
    {
        _handButtons.OnClickScissorsButton();
        Assert.AreEqual("あなたはチョキを選んでいます", _observerText.GetText());
    }


}
