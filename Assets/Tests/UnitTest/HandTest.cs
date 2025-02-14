using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HandTest
{
    Hand _hand;
    Mock<ISign> _mockSign;

    [SetUp]
    public void SetUp()
    {
        _mockSign = new Mock<ISign>();
        // Hand �̃C���X�^���X���쐬
        _hand = new Hand(_mockSign.Object);
    }

    // �I�u�U�[�o�[���ǉ��ł��邩
    [Test]
    public void AddObserver_AddsObserverSuccessfully()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();

        // Act
        _hand.AddObserver(mockObserver.Object);

        // Assert
        Assert.AreEqual(mockObserver.Object, _hand.GetObserver(0));
    }

    // �I�u�U�[�o�[���擾�ł��邩
    [Test]
    public void GetObserver_ReturnsCorrectObserver()
    {
        // Arrange
        var mockObserver1 = new Mock<IObserver>();
        var mockObserver2 = new Mock<IObserver>();

        _hand.AddObserver(mockObserver1.Object);
        _hand.AddObserver(mockObserver2.Object);

        // Act & Assert
        Assert.AreEqual(mockObserver1.Object, _hand.GetObserver(0));
        Assert.AreEqual(mockObserver2.Object, _hand.GetObserver(1));
    }

    [Test]
    public void SetCurrent_UpdatesCurrentSign()
    {
        // Arrange
        var expectedSign = Sign.Hand.Paper;

        // Act
        _hand.SetCurrent(Sign.Hand.Paper);

        // Assert
        Assert.AreEqual(expectedSign, _hand.Current);
    }

    [Test]
    public void GenerateText_CallsObserverUpMethod()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();
        _hand.AddObserver(mockObserver.Object);

        // Act
        _hand.SetCurrent(Sign.Hand.Paper);
        _hand.GenerateText();

        // Assert
        mockObserver.Verify(m => m.Up(_hand), Times.Once);
        _mockSign.Verify(m => m.ConvertHandToJapanese(_hand.Current));
    }

}
