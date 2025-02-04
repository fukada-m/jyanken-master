using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using Moq;

public class ObserverTextTest
{
    ObserverText observerText;
    TMP_Text text;
    GameManager gameManager;

    [SetUp]
    public void SetUp()
    {
        var observerTextObject = new GameObject("ObserverText");
        observerText = observerTextObject.AddComponent<ObserverText>();
        text = observerTextObject.AddComponent<TextMeshProUGUI>();
        gameManager = observerTextObject.AddComponent<GameManager>();

        // text��gameManager �� observerText �ɃZ�b�g
        typeof(ObserverText)
            .GetField("text", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(observerText, text);
        typeof(ObserverText)
            .GetField("gameManager", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(observerText, gameManager);
    }

    [Test]
    public void Up_UpdatesTextCorrectly()
    {
        // Ihand�^��Mock���쐬����Current�ɃO�[���Z�b�g
        var mockHand = new Mock<IHand>();
        mockHand.Setup(h => h.Current).Returns(GameManager.Sign.Stone);

        // GameManager�^��Mock���쐬
        var mockGameManager = new Mock<IGameManager>();
        mockGameManager.Setup(g => g.ConvertSignToJapanese(GameManager.Sign.Stone)).Returns("�O�[");

        // `GameManager.ConvertSignToJapanese()` ���g���Ċ��҂��镶������擾
        string expectedText = $"{mockGameManager.Object.ConvertSignToJapanese(GameManager.Sign.Stone)}��I��ł��܂�";

        // Act
        observerText.Up(mockHand.Object);

        // Assert
        Assert.AreEqual(expectedText, text.text);
    }

}
