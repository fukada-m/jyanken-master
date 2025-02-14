using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ReturnButtonTest
{
    ReturnButton returnButton;
    GameObject settingModal;
    GameObject menuButtons;

    [SetUp]
    public void ReturnButtonSetUp()
    {
        returnButton = new GameObject("ReturnButton").AddComponent<ReturnButton>();
        settingModal = new GameObject("SettingModal");
        menuButtons = new GameObject("MenuButtons");
        // ボタンクリックで有効化できるかテストするためfalseにする
        menuButtons.SetActive(false);

        // コンポジションを設定
        typeof(ReturnButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(returnButton, menuButtons);
        typeof(ReturnButton)
            .GetField("settingModal", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(returnButton, settingModal);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void OnClickButton_ReturnToStart()
    {
        returnButton.OnClickButton();
        Assert.IsTrue(menuButtons.activeSelf);
        Assert.IsFalse(settingModal.activeSelf);
    }

    
}
