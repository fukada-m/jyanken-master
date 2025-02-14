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
        // Notify型のMockを作成
        var mockSign = new Mock<ISign>();
        var mockHand = new Mock<Hand>(mockSign.Object);
        mockHand.Setup(m => m.Text).Returns("あなたはグーを選んでいます");

        // Act
        observerText.Up(mockHand.Object);

        // Assert
        Assert.AreEqual("あなたはグーを選んでいます", observerText.GetText());
    }
    [Test]
    public void Up_UpdatesTextHandPaper()
    {
        // Notify型のMockを作成
        var mockSign = new Mock<ISign>();
        var mockHand = new Mock<Hand>(mockSign.Object);
        mockHand.Setup(m => m.Text).Returns("あなたはパーを選んでいます");

        // Act
        observerText.Up(mockHand.Object);

        // Assert
        Assert.AreEqual("あなたはパーを選んでいます", observerText.GetText());
    }

}
