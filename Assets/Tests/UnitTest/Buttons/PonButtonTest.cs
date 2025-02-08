using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class PonButtonTest
{
    GameObject handButtons;
    PonButton ponButton;
    Mock<ILogicJyanken> moqLogicJyanken;

    [SetUp]
    public void PonButtonSetUp()
    {
        handButtons = new GameObject("handButtons");
        ponButton = new GameObject().AddComponent<PonButton>();
        moqLogicJyanken = new Mock<ILogicJyanken>();


        typeof(PonButton)
           .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
           .SetValue(ponButton, handButtons);
        typeof(PonButton)
           .GetField("logicJyanken", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
           .SetValue(ponButton, moqLogicJyanken.Object);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void onClickButton_JyankenJudge()
    {
        ponButton.onClickButton();
        // �n���h�{�^���Y�͔�\���ɂȂ�
        Assert.IsFalse(handButtons.activeSelf);
        // ����񂯂�̔��菈�����Ă΂ꂽ���m�F
         moqLogicJyanken.Verify(l => l.Judge(GameManager.Sign.Scissors, GameManager.Sign.Scissors), Times.Once);
        // message���A�b�v�f�[�g����
        
    }

}
