using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class HandButtonsTest
{
    HandButtons _handButtons;
    GameObject _ponButton;
    Mock<IObserver> _mockObserver;
    Mock<Notify> _mockNotify;
    Mock<IHand> _mockHand;

    [SetUp]
    public void HandButtonsTestSetUp()
    {
        _ponButton = new GameObject("PonButton");
        _handButtons = new GameObject().AddComponent<HandButtons>();
        _mockObserver = new Mock<IObserver>();
        _mockHand = new Mock<IHand>();
        _mockNotify = new Mock<Notify>();

        // テストを行うためにfalseにする
        _ponButton.SetActive(false);

        _handButtons.Initialize(_ponButton, _mockObserver.Object, _mockNotify.Object, _mockHand.Object);
    }

    [Test]
    public void OnClickStoneButton_SetsHandToStone()
    {
        _mockHand.Setup(m => m.ConvertHandToJapanese(_mockHand.Object.Current)).Returns("グー");
        var text = "あなたはグーを選んでいます";
        _handButtons.OnClickStoneButton();
        _mockHand.VerifySet(m => m.Current = Value.Hand.Stone, Times.Once);
        _mockNotify.Verify(m => m.SetTextNotify(text), Times.Once);
        Assert.IsTrue(_ponButton.activeSelf);
    }

    [Test]
    public void OnClickPaperButton_SetsHandToPaper()
    {
        _mockHand.Setup(m => m.ConvertHandToJapanese(_mockHand.Object.Current)).Returns("パー");
        var text = "あなたはパーを選んでいます";
        _handButtons.OnClickPaperButton();
        _mockHand.VerifySet(m => m.Current = Value.Hand.Paper, Times.Once);
        _mockNotify.Verify(m => m.SetTextNotify(text), Times.Once);
        Assert.IsTrue(_ponButton.activeSelf);
    }

    [Test]
    public void OnClickScissorsButton_SetsHandToScissors()
    {
        _mockHand.Setup(m => m.ConvertHandToJapanese(_mockHand.Object.Current)).Returns("チョキ");
        var text = "あなたはチョキを選んでいます";
        _handButtons.OnClickScissorsButton();
        _mockHand.VerifySet(m => m.Current = Value.Hand.Scissors, Times.Once);
        _mockNotify.Verify(m => m.SetTextNotify(text), Times.Once);
        Assert.IsTrue(_ponButton.activeSelf);
    }

}
