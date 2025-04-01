using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ReturnButtonTest
{
    ReturnButton returnButton;
    GameObject modal;
    GameObject menuButtons;
    GameObject messageText;

    [SetUp]
    public void ReturnButtonSetUp()
    {
        returnButton = new GameObject("ReturnButton").AddComponent<ReturnButton>();
        modal = new GameObject("Modal");
        menuButtons = new GameObject("MenuButtons");
        messageText = new GameObject("MessageText");
        // �{�^���N���b�N�ŗL�����ł��邩�e�X�g���邽��false�ɂ���
        menuButtons.SetActive(false);
        messageText.SetActive(false);

        // �R���|�W�V������ݒ�
        returnButton.Initialize(modal, menuButtons, messageText);
    }

    // A Test behaves as an ordinary method
    [Test]
    public void OnClickButton_ReturnToStart()
    {
        returnButton.OnClickButton();
        Assert.IsTrue(menuButtons.activeSelf);
        Assert.IsTrue(messageText.activeSelf);
        Assert.IsFalse(modal.activeSelf);
    }

    
}
