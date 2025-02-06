using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class HandButtonsTest
{
    HandButtons handButtons;
    Mock<IHand> mockHand;

    [SetUp]
    public void HandButtonsTestSetUp()
    {
        handButtons = new GameObject("HandButtons").AddComponent<HandButtons>();
        mockHand = new Mock<IHand>();
        // Hand ‚ÌˆË‘¶ŠÖŒW‚ðÝ’è
        typeof(HandButtons)
            .GetField("hand", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(handButtons, mockHand.Object);
    }

    [Test]
    public void OnClickStoneButton_SetsHandToStone()
    {
        handButtons.onClickStoneButton();
        mockHand.Verify(h => h.SetCurrent(GameManager.Sign.Stone), Times.Once);
    }

    [Test]
    public void OnClickPaperButton_SetsHandToPaper()
    {
        handButtons.onClickPaperButton();
        mockHand.Verify(h => h.SetCurrent(GameManager.Sign.Paper), Times.Once);
    }

    [Test]
    public void OnClickScissorsButton_SetsHandToScissors()
    {
        handButtons.onClickScissorsButton();
        mockHand.Verify(h => h.SetCurrent(GameManager.Sign.Scissors), Times.Once);
    }

}
