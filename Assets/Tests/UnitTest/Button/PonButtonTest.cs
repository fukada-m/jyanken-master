using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class PonButtonTest
{
    GameObject handButtons;
    PonButton ponButton;
    Mock<IObserver> mockObserver;
    Mock<Notify> mockNotify;
    Mock<ILogicJyanken> mockLogicJyanken;
    Mock<IEnemyHand> mockEnemyHand;

    [SetUp]
    public void PonButtonSetUp()
    {
        handButtons = new GameObject("handButtons");
        ponButton = new GameObject().AddComponent<PonButton>();
        mockObserver = new Mock<IObserver>();
        mockNotify = new Mock<Notify>();
        mockLogicJyanken = new Mock<ILogicJyanken>();
        mockEnemyHand = new Mock<IEnemyHand>();
        mockEnemyHand.Setup(s => s.PickHand()).Returns(Sign.Hand.Stone);
        ponButton.Initialize(handButtons, mockObserver.Object,mockNotify.Object, mockLogicJyanken.Object, mockEnemyHand.Object);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void OnClickButton_JyankenJudge()
    {
        ponButton.OnClickButton();
        // �n���h�{�^���Y�͔�\���ɂȂ�
        Assert.IsFalse(handButtons.activeSelf);
        mockEnemyHand.Verify(e => e.PickHand(), Times.Once);
        // ����񂯂�̔��菈�����Ă΂ꂽ���m�F
         //mockLogicJyanken.Verify(l => l.Judge(Sign.Hand.Scissors, Sign.Hand.Stone), Times.Once);
    }

}
