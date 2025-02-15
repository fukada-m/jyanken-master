using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NotifyTest
{
    Notify _notify;
    Mock<IObserver> _mockObserver;

    [SetUp]
    public void SetUp()
    {
        _notify = new Notify();
        _mockObserver = new Mock<IObserver>();
    }

    // オブザーバーが追加できるか
    [Test]
    public void AddObserver_AddsObserverSuccessfully()
    {

        // Act
        _notify.AddObserver(_mockObserver.Object);

        // Assert
        Assert.AreEqual(_mockObserver.Object, _notify.GetObserver(0));
    }

    // 複数のオブザーバーが追加できるか
    [Test]
    public void GetObserver_ReturnsCorrectObserver()
    {
        // Arrange
        var mockObserver1 = new Mock<IObserver>();
        var mockObserver2 = new Mock<IObserver>();

        _notify.AddObserver(mockObserver1.Object);
        _notify.AddObserver(mockObserver2.Object);

        // Act & Assert
        Assert.AreEqual(mockObserver1.Object, _notify.GetObserver(0));
        Assert.AreEqual(mockObserver2.Object, _notify.GetObserver(1));
    }

    // テキストをセットしてオブザーバーが更新できるか？
    [Test]
    public void SetTextNotify()
    {
        _notify.AddObserver(_mockObserver.Object);
        _notify.SetTextNotify("テストメッセージ");
        Assert.AreEqual("テストメッセージ", _notify.Text);
        _mockObserver.Verify(m => m.Up(_notify), Times.Once);
    }
}
