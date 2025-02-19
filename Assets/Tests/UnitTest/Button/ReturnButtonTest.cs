using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ReturnButtonTest
{
    ReturnButton returnButton;
    GameObject settingModal;
    GameObject menuButtons;
    GameObject messageText;

    [SetUp]
    public void ReturnButtonSetUp()
    {
        returnButton = new GameObject("ReturnButton").AddComponent<ReturnButton>();
        settingModal = new GameObject("SettingModal");
        menuButtons = new GameObject("MenuButtons");
        messageText = new GameObject("MessageText");
        // ボタンクリックで有効化できるかテストするためfalseにする
        menuButtons.SetActive(false);
        messageText.SetActive(false);

        // コンポジションを設定
        returnButton.Initialize(settingModal, menuButtons, messageText);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void OnClickButton_ReturnToStart()
    {
        returnButton.OnClickButton();
        Assert.IsTrue(menuButtons.activeSelf);
        Assert.IsTrue(messageText.activeSelf);
        Assert.IsFalse(settingModal.activeSelf);
    }

    
}
