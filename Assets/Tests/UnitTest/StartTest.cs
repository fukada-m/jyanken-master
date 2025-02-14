using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StartTest
{
    Notify start;
    [SetUp]
    public void SetUp()
    {
        // Start のインスタンスを作成
        start = new Start();
    }

    // オブザーバーが追加できるか
    [Test]
    public void AddObserver_AddsObserverSuccessfully()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();

        // Act
        start.AddObserver(mockObserver.Object);

        // Assert
        Assert.AreEqual(mockObserver.Object, start.GetObserver(0));
    }

    // オブザーバーが取得できるか
    [Test]
    public void GetObserver_ReturnsCorrectObserver()
    {
        // Arrange
        var mockObserver1 = new Mock<IObserver>();
        var mockObserver2 = new Mock<IObserver>();

        start.AddObserver(mockObserver1.Object);
        start.AddObserver(mockObserver2.Object);

        // Act & Assert
        Assert.AreEqual(mockObserver1.Object, start.GetObserver(0));
        Assert.AreEqual(mockObserver2.Object, start.GetObserver(1));
    }

    [Test]
    public void GenerateText_CallsObserverUpMethod()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();
        start.AddObserver(mockObserver.Object);

        // Act
        start.GenerateText();

        // Assert
        mockObserver.Verify(o => o.Up(start), Times.Once);
    }
}
