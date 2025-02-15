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

    // �I�u�U�[�o�[���ǉ��ł��邩
    [Test]
    public void AddObserver_AddsObserverSuccessfully()
    {

        // Act
        _notify.AddObserver(_mockObserver.Object);

        // Assert
        Assert.AreEqual(_mockObserver.Object, _notify.GetObserver(0));
    }

    // �����̃I�u�U�[�o�[���ǉ��ł��邩
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

    // �e�L�X�g���Z�b�g���ăI�u�U�[�o�[���X�V�ł��邩�H
    [Test]
    public void SetTextNotify()
    {
        _notify.AddObserver(_mockObserver.Object);
        _notify.SetTextNotify("�e�X�g���b�Z�[�W");
        Assert.AreEqual("�e�X�g���b�Z�[�W", _notify.Text);
        _mockObserver.Verify(m => m.Up(_notify), Times.Once);
    }
}
