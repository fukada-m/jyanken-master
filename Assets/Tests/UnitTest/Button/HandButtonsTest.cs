using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class HandButtonsTest
{
    HandButtons _handButtons;
    Mock<Hand> _mockHand;
    Mock<ISign> _mockSign;

    [SetUp]
    public void HandButtonsTestSetUp()
    {
        _handButtons = new GameObject().AddComponent<HandButtons>();
        _mockSign = new Mock<ISign>();
        _mockHand = new Mock<Hand>(_mockSign.Object);
        _handButtons.Initialize(_mockHand.Object);
    }

    [Test]
    public void OnClickStoneButton_SetsHandToStone()
    {
        _handButtons.OnClickStoneButton();
        _mockHand.Verify(m => m.SetCurrent(Sign.Hand.Stone), Times.Once);
        _mockHand.Verify(m => m.GenerateText(), Times.Once);
    }

    [Test]
    public void OnClickPaperButton_SetsHandToPaper()
    {
        _handButtons.OnClickPaperButton();
        _mockHand.Verify(m => m.SetCurrent(Sign.Hand.Paper), Times.Once);
        _mockHand.Verify(m => m.GenerateText(), Times.Once);
    }

    [Test]
    public void OnClickScissorsButton_SetsHandToScissors()
    {
        _handButtons.OnClickScissorsButton();
        _mockHand.Verify(m => m.SetCurrent(Sign.Hand.Scissors), Times.Once);
        _mockHand.Verify(m => m.GenerateText(), Times.Once);
    }

}
