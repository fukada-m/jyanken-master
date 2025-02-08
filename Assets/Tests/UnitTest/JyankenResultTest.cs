using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.XR;

public class JyankenResultTest
{
    JyankenResult jyankenResult;

    [SetUp]
    public void JyankenResultSetup()
    {
        jyankenResult = new JyankenResult();
    }

    // オブザーバーが追加できるか
    [Test]
    public void AddObserver_AddsObserverSuccessfully()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();

        // Act
        jyankenResult.AddObserver(mockObserver.Object);

        // Assert
        Assert.AreEqual(mockObserver.Object, jyankenResult.GetObserver(0));
    }

    // オブザーバーが取得できるか
    [Test]
    public void GetObserver_ReturnsCorrectObserver()
    {
        // Arrange
        var mockObserver1 = new Mock<IObserver>();
        var mockObserver2 = new Mock<IObserver>();

        jyankenResult.AddObserver(mockObserver1.Object);
        jyankenResult.AddObserver(mockObserver2.Object);

        // Act & Assert
        Assert.AreEqual(mockObserver1.Object, jyankenResult.GetObserver(0));
        Assert.AreEqual(mockObserver2.Object, jyankenResult.GetObserver(1));
    }

    [Test]
    public void SetResult_UpdatesCurrentResult()
    {
        // Arrange
        var expectedResult = GameManager.Result.WIn;

        // Act
        jyankenResult.SetResult(expectedResult);

        // Assert
        Assert.AreEqual(jyankenResult.Result, expectedResult);
    }
    public void NotifyObservers_CallsObserverUpMethod()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();
        jyankenResult.AddObserver(mockObserver.Object);

        // Act
        jyankenResult.SetResult(GameManager.Result.WIn);

        // Assert
        mockObserver.Verify(o => o.Up($"あなたの{jyankenResult.Result}です。"), Times.Once);
    }
}
