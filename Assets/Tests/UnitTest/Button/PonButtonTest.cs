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
    Mock<Notify> mockNotify;
    Mock<ILogicJyanken> mockLogicJyanken;
    Mock<IEnemyHand> mockEnemyHand;
    Mock<IHand> mockHand;
    Mock<IResult> mockResult;

    [SetUp]
    public void PonButtonSetUp()
    {
        handButtons = new GameObject("HandButtons");
        ponButtonOBJ = new GameObject("PonButton");
        ponButton = new GameObject().AddComponent<PonButton>();
        mockNotify = new Mock<Notify>();
        mockLogicJyanken = new Mock<ILogicJyanken>();
        mockEnemyHand = new Mock<IEnemyHand>();
        mockHand = new Mock<IHand>();
        mockResult = new Mock<IResult>();
        mockEnemyHand.Setup(s => s.PickHand()).Returns(Value.Hand.Stone);
        mockHand.Setup(m => m.Current).Returns(Value.Hand.Scissors);
        mockHand.Setup(m => m.ConvertHandToJapanese(Value.Hand.Stone)).Returns("�O�[");
        ponButton.Initialize(
            handButtons,
            ponButtonOBJ,
            mockNotify.Object,
            mockLogicJyanken.Object,
            mockEnemyHand.Object,
            mockHand.Object,
            mockResult.Object
         );
    }
    // �G�l�~�[���n���h��I�Ԃ܂Ńe�X�g����
    [Test]
    public void OnClickButton_JyankenJudge()
    {
        ponButton.OnClickButton();
        // �n���h�{�^���Y�͔�\���ɂȂ�
        Assert.IsFalse(handButtons.activeSelf);
        // CPU���o��������߂�
        mockEnemyHand.Verify(e => e.PickHand(), Times.Once);
        // CPU���o�������ϊ�����
        mockHand.Verify(m => m.ConvertHandToJapanese(mockEnemyHand.Object.PickHand()), Times.Once);
        // �I�u�U�[�o�[�ɒʒm�𑗂�
        mockNotify.Verify(m => m.SetTextNotify("����̓O�[��I�т܂���"), Times.Once);
        // ����񂯂�̏��s���菈�����Ă΂��
        mockLogicJyanken.Verify(m => m.Judge(Value.Hand.Scissors, Value.Hand.Stone), Times.Once);
        // �|���{�^������\���ɂȂ�
        Assert.IsFalse(ponButtonOBJ.activeSelf);
    }
    [UnitySetUp]
    //public IEnumerator UnitySetup()
    //{
    //    yield return null;
    //    handButtons = new GameObject("HandButtons");
    //    ponButtonOBJ = new GameObject("PonButton");
    //    ponButton = new GameObject().AddComponent<PonButton>();
    //    mockNotify = new Mock<Notify>();
    //    mockLogicJyanken = new Mock<ILogicJyanken>();
    //    mockEnemyHand = new Mock<IEnemyHand>();
    //    mockHand = new Mock<IHand>();
    //    mockResult = new Mock<IResult>();
    //    mockEnemyHand.Setup(s => s.PickHand()).Returns(Value.Hand.Stone);
    //    mockHand.Setup(m => m.Current).Returns(Value.Hand.Scissors);
    //    mockHand.Setup(m => m.ConvertHandToJapanese(Value.Hand.Stone)).Returns("�O�[");
    //    ponButton.Initialize(
    //        handButtons,
    //        ponButtonOBJ,
    //        mockNotify.Object,
    //        mockLogicJyanken.Object,
    //        mockEnemyHand.Object,
    //        mockHand.Object,
    //        mockResult.Object
    //     );
    //}

    [UnityTest]
    public IEnumerator OnClickButton_Wait1Second()
    {
        ponButton.OnClickButton();
        //�I�u�U�[�o�[�Ɍ��ʂ��ʒm�����
        mockNotify.Verify(m => m.SetTextNotify("���Ȃ��̕����ł�"), Times.Once);
        yield return null;
    }

}
