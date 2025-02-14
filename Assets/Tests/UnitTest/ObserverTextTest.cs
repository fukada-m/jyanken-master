using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using Moq;

public class ObserverTextTest
{
    ObserverText observerText;

    [SetUp]
    public void SetUp()
    {
        var observerTextObject = new GameObject("ObserverText");
        observerText = observerTextObject.AddComponent<ObserverText>();
        var text = observerTextObject.AddComponent<TextMeshProUGUI>();
        observerText.Initialize(text);
    }
   
    [Test]
    public void Up_UpdatesTextHandStone()
    {
        // Notify�^��Mock���쐬
        var mockSign = new Mock<ISign>();
        var mockHand = new Mock<Hand>(mockSign.Object);
        mockHand.Setup(m => m.Text).Returns("���Ȃ��̓O�[��I��ł��܂�");

        // Act
        observerText.Up(mockHand.Object);

        // Assert
        Assert.AreEqual("���Ȃ��̓O�[��I��ł��܂�", observerText.GetText());
    }
    [Test]
    public void Up_UpdatesTextHandPaper()
    {
        // Notify�^��Mock���쐬
        var mockSign = new Mock<ISign>();
        var mockHand = new Mock<Hand>(mockSign.Object);
        mockHand.Setup(m => m.Text).Returns("���Ȃ��̓p�[��I��ł��܂�");

        // Act
        observerText.Up(mockHand.Object);

        // Assert
        Assert.AreEqual("���Ȃ��̓p�[��I��ł��܂�", observerText.GetText());
    }

}
