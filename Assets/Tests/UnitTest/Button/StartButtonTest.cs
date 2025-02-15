using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StartButtonTest
{
    GameObject _menuButtons;
    GameObject _handButtons;
    StartButton _startButton;
    Mock<IObserver> _mockObserver;
    Mock<Notify> _mockNotify;

    [SetUp]
    public void StartButtonSetUp()
    {
        _menuButtons = new GameObject("MenuButtons");
        _handButtons = new GameObject("HandButtons");
        _startButton = new GameObject().AddComponent<StartButton>();
        _mockNotify = new Mock<Notify>();
        _mockObserver = new Mock<IObserver>();
        // ÉeÉXÉgÇ∑ÇÈÇΩÇﬂÇ…falseÇ…ê›íË
        _handButtons.SetActive(false);
        _startButton.Initialize(_menuButtons, _handButtons, _mockObserver.Object,  _mockNotify.Object);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void onClickButton_StartJyanken()
    {
        _startButton.OnClickButton();
        // Assert
        Assert.IsTrue(_handButtons.activeSelf);
        Assert.IsFalse(_menuButtons.activeSelf);
    }
}
