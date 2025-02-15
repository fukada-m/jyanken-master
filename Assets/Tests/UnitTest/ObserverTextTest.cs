using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using Moq;

public class ObserverTextTest
{
    ObserverText _observerText;

    [SetUp]
    public void SetUp()
    {
        _observerText = new GameObject().AddComponent<ObserverText>();
        var text = new GameObject().AddComponent<TextMeshProUGUI>();
        _observerText.Initialize(text);
    }
   
    [Test]
    public void Up_UpdatesTextHandStone()
    {
        // Notify�^��Mock���쐬
        var mockSign = new Mock<ISign>();
        var mockHand = new Mock<Notify>();
        mockHand.Setup(m => m.Text).Returns("���Ȃ��̓O�[��I��ł��܂�");

        // Act
        _observerText.Up(mockHand.Object);

        // Assert
        Assert.AreEqual("���Ȃ��̓O�[��I��ł��܂�", _observerText.GetText());
    }
    [Test]
    public void Up_UpdatesTextHandPaper()
    {
        // Notify�^��Mock���쐬
        var mockSign = new Mock<ISign>();
        var mockNotify = new Mock<Notify>();
        mockNotify.Setup(m => m.Text).Returns("���Ȃ��̓p�[��I��ł��܂�");

        // Act
        _observerText.Up(mockNotify.Object);

        // Assert
        Assert.AreEqual("���Ȃ��̓p�[��I��ł��܂�", _observerText.GetText());
    }

}
