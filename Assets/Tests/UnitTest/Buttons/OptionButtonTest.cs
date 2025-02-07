using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OptionButtonTest
{
    OptionButton optionButton;
    GameObject setting;
    GameObject menuButtons;

    [SetUp]
    public void OptionButtonSetUp()
    {
        optionButton = new GameObject("OptionButton").AddComponent<OptionButton>();
        setting = new GameObject("Setting");
        menuButtons = new GameObject("MenuButtons");
        // �{�^���N���b�N�ŗL�����ł��邩�e�X�g���邽�߂�false�ɂ���
        setting.SetActive(false);

        // �R���|�W�V������ݒ�
        typeof(OptionButton)
            .GetField("menuButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(optionButton, menuButtons);
        typeof(OptionButton)
            .GetField("setting", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(optionButton, setting);
    } 
    // A Test behaves as an ordinary method
    [Test]
    public void OptionButton_ShowSetting()
    {
        optionButton.onClickButton();
        Assert.IsTrue(setting.activeSelf);
        Assert.IsFalse(menuButtons.activeSelf);
    }
}
