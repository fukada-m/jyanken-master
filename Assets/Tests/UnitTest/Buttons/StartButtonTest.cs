using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.XR;

public class StartButtonTest
{
    GameObject menuButtons;
    GameObject handButtons;
    StartButton startButton;

    [SetUp]
    public void StartButtonSetUp()
    {
        handButtons = new GameObject("HandButtons");
        startButton = new GameObject("Startbutton").AddComponent<StartButton>();
        menuButtons = new GameObject("MenuButtons");
        // テストするためにfalseに設定
        handButtons.SetActive(false);

        // コンポジションを設定
        typeof(StartButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(startButton, menuButtons);
        typeof(StartButton)
            .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(startButton, handButtons);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void onClick_StartJyanken()
    {
        var mockObserver = new Mock<IObserver>();
        startButton.AddObserver(mockObserver.Object);
        
        startButton.onClick();
        // Assert
        Assert.IsTrue(handButtons.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
        mockObserver.Verify(o => o.Up("何の手を出すか決めてください"), Times.Once);
    }

    // オブザーバーが追加できるか
    [Test]
    public void AddObserver_AddsObserverSuccessfully()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();

        // Act
        startButton.AddObserver(mockObserver.Object);

        // Assert
        Assert.AreEqual(mockObserver.Object, startButton.GetObserver(0));
    }

    [Test]
    public void GetObserver_ReturnsCorrectObserver()
    {
        // Arrange
        var mockObserver1 = new Mock<IObserver>();
        var mockObserver2 = new Mock<IObserver>();

        startButton.AddObserver(mockObserver1.Object);
        startButton.AddObserver(mockObserver2.Object);

        // Act & Assert
        Assert.AreEqual(mockObserver1.Object, startButton.GetObserver(0));
        Assert.AreEqual(mockObserver2.Object, startButton.GetObserver(1));
    }
}
