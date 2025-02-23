using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class PonButtonTest
{
    GameObject handButtons;
    GameObject ponButtonOBJ;
    PonButton ponButton;
    Mock<IObserver> mockObserver;
    Mock<Notify> mockNotify;
    Mock<ILogicJyanken> mockLogicJyanken;
    Mock<IEnemyHand> mockEnemyHand;
    Mock<IHand> mockHand;

    [SetUp]
    public void PonButtonSetUp()
    {
        handButtons = new GameObject("HandButtons");
        ponButtonOBJ = new GameObject("PonButton");
        ponButton = new GameObject().AddComponent<PonButton>();
        mockObserver = new Mock<IObserver>();
        mockNotify = new Mock<Notify>();
        mockLogicJyanken = new Mock<ILogicJyanken>();
        mockEnemyHand = new Mock<IEnemyHand>();
        mockHand = new Mock<IHand>();
        mockEnemyHand.Setup(s => s.PickHand()).Returns(Value.Hand.Stone);
        mockHand.Setup(m => m.ConvertHandToJapanese(Value.Hand.Stone)).Returns("�O�[");
        ponButton.Initialize(
            handButtons,
            ponButtonOBJ,
            mockObserver.Object,
            mockNotify.Object,
            mockLogicJyanken.Object,
            mockEnemyHand.Object,
            mockHand.Object
         );
    }
    // A Test behaves as an ordinary method
    [Test]
    public void OnClickButton_JyankenJudge()
    {
        ponButton.OnClickButton();
        // �n���h�{�^���Y�͔�\���ɂȂ�
        Assert.IsFalse(handButtons.activeSelf);
        // �|���{�^������\���ɂȂ�
        Assert.IsFalse(ponButtonOBJ.activeSelf);
        // CPU���o��������߂�
        mockEnemyHand.Verify(e => e.PickHand(), Times.Once);
        // �I�u�U�[�o�[�ɒʒm�𑗂�
        mockNotify.Verify(m => m.SetTextNotify("����̓O�[��I�т܂���"), Times.Once);
        // ����񂯂�̏��s���菈�����Ă΂��
        mockLogicJyanken.Verify(l => l.Judge(Value.Hand.Scissors, Value.Hand.Stone), Times.Once);
        // �I�u�U�[�o�[�ɒʒm�𑗂�
        mockNotify.Verify(m => m.SetTextNotify("���Ȃ��̕����ł�"), Times.Once);
    }

}
