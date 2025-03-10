using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OptionButtonTest
{
    OptionButton optionButton;
    GameObject settingModal;
    GameObject menuButtons;
    GameObject massageText;
    [SetUp]
    public void OptionButtonSetUp()
    {
        optionButton = new GameObject("OptionButton").AddComponent<OptionButton>();
        settingModal = new GameObject("SettingModal");
        menuButtons = new GameObject("MenuButtons");
        massageText = new GameObject("MassageText");

        // ボタンクリックで有効化できるかテストするためにfalseにする
        settingModal.SetActive(false);

        optionButton.Initialize(settingModal, menuButtons, massageText);
    } 
    // A Test behaves as an ordinary method
    [Test]
    public void OptionButton_ShowSetting()
    {
        optionButton.OnClickButton();
        Assert.IsTrue(settingModal.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
        Assert.IsFalse(massageText.activeSelf);
    }
}
