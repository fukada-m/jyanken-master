using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class HandButtonsTest
{
    HandButtons _handButtons;
    Mock<Notify> _mockNotify;
    Mock<ISign> _mockSign;

    [SetUp]
    public void HandButtonsTestSetUp()
    {
        _handButtons = new GameObject().AddComponent<HandButtons>();
        _mockSign = new Mock<ISign>();
        _mockNotify = new Mock<Notify>();
        _handButtons.Initialize(_mockNotify.Object, _mockSign.Object);
    }

    [Test]
    public void OnClickStoneButton_SetsHandToStone()
    {
        _mockSign.Setup(m => m.ConvertHandToJapanese(_mockSign.Object.Current)).Returns("グー");
        var text = "あなたはグーを選んでいます";
        _handButtons.OnClickStoneButton();
        _mockSign.VerifySet(m => m.Current = Sign.Hand.Stone, Times.Once);
        _mockNotify.Verify(m => m.SetTextNotify(text), Times.Once);
    }

    [Test]
    public void OnClickPaperButton_SetsHandToPaper()
    {
        _mockSign.Setup(m => m.ConvertHandToJapanese(_mockSign.Object.Current)).Returns("パー");
        var text = "あなたはパーを選んでいます";
        _handButtons.OnClickPaperButton();
        _mockSign.VerifySet(m => m.Current = Sign.Hand.Paper, Times.Once);
        _mockNotify.Verify(m => m.SetTextNotify(text), Times.Once);
    }

    [Test]
    public void OnClickScissorsButton_SetsHandToScissors()
    {
        _mockSign.Setup(m => m.ConvertHandToJapanese(_mockSign.Object.Current)).Returns("チョキ");
        var text = "あなたはチョキを選んでいます";
        _handButtons.OnClickScissorsButton();
        _mockSign.VerifySet(m => m.Current = Sign.Hand.Scissors, Times.Once);
        _mockNotify.Verify(m => m.SetTextNotify(text), Times.Once);
    }

}
