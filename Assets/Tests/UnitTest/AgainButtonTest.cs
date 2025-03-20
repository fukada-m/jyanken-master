using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AgainButtonTest
{
    AgainButton againButton;
    GameObject againButtonOBJ;
    GameObject handButtons;
    GameObject endButtonOBJ;
    Mock<Notify> mockNotify;


    [SetUp]
    public void SetUp()
    {
        againButton = new AgainButton();
        againButtonOBJ = new GameObject();
        handButtons = new GameObject();
        // ������Ԃ͔�\��
        handButtons.SetActive(false);
        endButtonOBJ = new GameObject();
        mockNotify = new Mock<Notify>();
        againButton.Initialize(handButtons, againButtonOBJ, endButtonOBJ, mockNotify.Object);
    }

    [Test]
    public void OnClickButton_Restart()
    {
        againButton.OnClickButton();
        // �n���h�{�^���Y��\��
        Assert.IsTrue(handButtons.activeSelf);
        // ���g���\��
        Assert.IsFalse(againButtonOBJ.activeSelf);
        // �G���h�{�^�����\��
        Assert.IsFalse(endButtonOBJ.activeSelf);
        // �e�L�X�g���b�Z�[�W��"���̎���o�������߂Ă�������"�ɕύX
        mockNotify.Verify(m => m.SetTextNotify("���̎���o�������߂Ă�������"), Times.Once);
    }


}
