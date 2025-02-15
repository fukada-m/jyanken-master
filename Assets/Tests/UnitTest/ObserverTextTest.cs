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
        // Notify型のMockを作成
        var mockSign = new Mock<ISign>();
        var mockHand = new Mock<Notify>();
        mockHand.Setup(m => m.Text).Returns("あなたはグーを選んでいます");

        // Act
        _observerText.Up(mockHand.Object);

        // Assert
        Assert.AreEqual("あなたはグーを選んでいます", _observerText.GetText());
    }
    [Test]
    public void Up_UpdatesTextHandPaper()
    {
        // Notify型のMockを作成
        var mockSign = new Mock<ISign>();
        var mockNotify = new Mock<Notify>();
        mockNotify.Setup(m => m.Text).Returns("あなたはパーを選んでいます");

        // Act
        _observerText.Up(mockNotify.Object);

        // Assert
        Assert.AreEqual("あなたはパーを選んでいます", _observerText.GetText());
    }

}
