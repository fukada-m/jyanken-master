using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class PonButtonTest
{
    GameObject handButtons;
    GameObject ponButtonOBJ;
    GameObject resultButtonOBJ;
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
        resultButtonOBJ = new GameObject("ResultButton");
        // テスト開始時は非表示になっている
        resultButtonOBJ.SetActive(false);
        ponButton = ponButtonOBJ.AddComponent<PonButton>();
        mockNotify = new Mock<Notify>();
        mockLogicJyanken = new Mock<ILogicJyanken>();
        mockEnemyHand = new Mock<IEnemyHand>();
        mockHand = new Mock<IHand>();
        mockResult = new Mock<IResult>();
        mockHand.Setup(m => m.Current).Returns(Value.Hand.Scissors);
        mockHand.Setup(m => m.ConvertHandToJapanese(Value.Hand.Stone)).Returns("グー");
        mockEnemyHand.Setup(m => m.Current).Returns(Value.Hand.Stone);
        ponButton.Initialize(
            handButtons,
            ponButtonOBJ,
            resultButtonOBJ,
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
        mockHand.Verify(m => m.ConvertHandToJapanese(mockEnemyHand.Object.Current), Times.Once);
        // オブザーバーに通知を送る
        mockNotify.Verify(m => m.SetTextNotify("相手はグーを選びました"), Times.Once);
        // じゃんけんの勝敗判定処理が呼ばれる
        mockLogicJyanken.Verify(m => m.Judge(Value.Hand.Scissors, Value.Hand.Stone), Times.Once);
        // ポンボタンが非表示になる
        Assert.IsFalse(ponButtonOBJ.activeSelf);
        // resultボタンが表示される
        Assert.IsTrue(resultButtonOBJ.activeSelf);
    }

}
