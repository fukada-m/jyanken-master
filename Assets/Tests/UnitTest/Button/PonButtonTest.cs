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
        mockHand.Setup(m => m.ConvertHandToJapanese(Value.Hand.Stone)).Returns("グー");
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
    // エネミーがハンドを選ぶまでテストする
    [Test]
    public void OnClickButton_JyankenJudge()
    {
        ponButton.OnClickButton();
        // ハンドボタンズは非表示になる
        Assert.IsFalse(handButtons.activeSelf);
        // CPUが出す手を決める
        mockEnemyHand.Verify(e => e.PickHand(), Times.Once);
        // CPUが出した手を変換する
        mockHand.Verify(m => m.ConvertHandToJapanese(mockEnemyHand.Object.PickHand()), Times.Once);
        // オブザーバーに通知を送る
        mockNotify.Verify(m => m.SetTextNotify("相手はグーを選びました"), Times.Once);
        // じゃんけんの勝敗判定処理が呼ばれる
        mockLogicJyanken.Verify(m => m.Judge(Value.Hand.Scissors, Value.Hand.Stone), Times.Once);
        // ポンボタンが非表示になる
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
    //    mockHand.Setup(m => m.ConvertHandToJapanese(Value.Hand.Stone)).Returns("グー");
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
        //オブザーバーに結果が通知される
        mockNotify.Verify(m => m.SetTextNotify("あなたの負けです"), Times.Once);
        yield return null;
    }

}
