using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class GameStarterTest
{
    GameStarter _gameStarter;
    GameObject _handButtons;
    GameObject _settingModal;
    GameObject _ponBotton;

    [SetUp]
    public void GameStarterSetUp()
    {
        _gameStarter = new GameObject().AddComponent<GameStarter>();
        _handButtons = new GameObject("HandButtons");
        _settingModal = new GameObject("SettingModal");
        _ponBotton = new GameObject("PonButton");

        _gameStarter.Initialize(
            _handButtons, 
            _settingModal, 
            _ponBotton
         );
    }

    [Test]
    public void Start_GameStarter()
    {
        _gameStarter.TestStart();
        // ƒ{ƒ^ƒ“‚ª”ñ•\Ž¦‚É‚È‚Á‚Ä‚¢‚é‚©
        Assert.IsFalse(_handButtons.activeSelf);
        Assert.IsFalse(_settingModal.activeSelf);
        Assert.IsFalse(_ponBotton.activeSelf);


    }
}
