using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class GameStarterTest
{
    GameStarter _gameStarter;
    GameObject _handButtonsOBJ;
    GameObject _settingModal;
    GameObject _ponBottonOBJ;
    GameObject _resultButtonOBJ;
    Mock<HandButtons> _mockHandButtons;
    Mock<PonButton> _mockPonButton;
    Mock<ResultButton> _mockResultButton;

    [SetUp]
    public void GameStarterSetUp()
    {
        _gameStarter = new GameObject().AddComponent<GameStarter>();
        _handButtonsOBJ = new GameObject("HandButtons");
        _settingModal = new GameObject("SettingModal");
        _ponBottonOBJ = new GameObject("PonButton");
        _resultButtonOBJ = new GameObject("ResultButton");
        _mockHandButtons = new Mock<HandButtons>();
        _mockPonButton = new Mock<PonButton>();
        _mockResultButton = new Mock<ResultButton>();

        _gameStarter.Initialize(
            _handButtonsOBJ, 
            _settingModal, 
            _ponBottonOBJ,
            _resultButtonOBJ,
            _mockResultButton.Object,
            _mockHandButtons.Object,
            _mockPonButton.Object
         );
    }

    [Test]
    public void Start_GameStarter()
    {
        _gameStarter.TestStart();
        // ボタンが非表示になっているか
        Assert.IsFalse(_handButtonsOBJ.activeSelf);
        Assert.IsFalse(_settingModal.activeSelf);
        Assert.IsFalse(_ponBottonOBJ.activeSelf);
        Assert.IsFalse(_resultButtonOBJ.activeSelf );
        // HandをDI出来ているか
        _mockHandButtons.VerifySet( m => m.PlayerHand = It.IsAny<PlayerHand>(), Times.Once);
        _mockPonButton.VerifySet(m => m.Hand = It.IsAny<Hand>(), Times.Once);
        // ResultをDI出来ているか
        _mockPonButton.VerifySet(m => m.Result = It.IsAny<Result>(), Times.Once);
        _mockResultButton.VerifySet(m => m.Result = It.IsAny<Result>(), Times.Once);
    }
}
