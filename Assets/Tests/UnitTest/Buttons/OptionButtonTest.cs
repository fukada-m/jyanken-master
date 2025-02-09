using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OptionButtonTest
{
    OptionButton optionButton;
    GameObject settingModal;
    GameObject menuButtons;

    [SetUp]
    public void OptionButtonSetUp()
    {
        optionButton = new GameObject("OptionButton").AddComponent<OptionButton>();
        settingModal = new GameObject("SettingModal");
        menuButtons = new GameObject("MenuButtons");
        // �{�^���N���b�N�ŗL�����ł��邩�e�X�g���邽�߂�false�ɂ���
        settingModal.SetActive(false);

        // �R���|�W�V������ݒ�
        typeof(OptionButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(optionButton, menuButtons);
        typeof(OptionButton)
            .GetField("settingModal", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(optionButton, settingModal);
    } 
    // A Test behaves as an ordinary method
    [Test]
    public void OptionButton_ShowSetting()
    {
        optionButton.OnClickButton();
        Assert.IsTrue(settingModal.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
    }
}
