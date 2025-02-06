using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.XR;

public class HandTest
{
    Hand hand;

    [SetUp]
    public void SetUp()
    {
        // Hand のインスタンスを作成
        hand= new GameObject("Hand").AddComponent<Hand>();
    }

    // オブザーバーが追加できるか
    [Test]
    public void AddObserver_AddsObserverSuccessfully()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();

        // Act
        hand.AddObserver(mockObserver.Object);

        // Assert
        Assert.AreEqual(mockObserver.Object, hand.GetObserver(0));
    }

    [Test]
    public void GetObserver_ReturnsCorrectObserver()
    {
        // Arrange
        var mockObserver1 = new Mock<IObserver>();
        var mockObserver2 = new Mock<IObserver>();

        hand.AddObserver(mockObserver1.Object);
        hand.AddObserver(mockObserver2.Object);

        // Act & Assert
        Assert.AreEqual(mockObserver1.Object, hand.GetObserver(0));
        Assert.AreEqual(mockObserver2.Object, hand.GetObserver(1));
    }

    [Test]
    public void SetCurrent_UpdatesCurrentSign()
    {
        // Arrange
        var expectedSign = GameManager.Sign.Paper;

        // Act
        hand.SetCurrent(expectedSign);

        // Assert
        Assert.AreEqual(expectedSign, hand.Current);
    }

    [Test]
    public void NotifyObservers_CallsObserverUpMethod()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();
        hand.AddObserver(mockObserver.Object);

        // Act
        hand.SetCurrent(GameManager.Sign.Stone);

        // Assert
        mockObserver.Verify(o => o.Up(hand), Times.Once);
    }
}
