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
        mockHand.Setup(m => m.ConvertHandToJapanese(Value.Hand.Stone)).Returns("グー");
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
        // ハンドボタンズは非表示になる
        Assert.IsFalse(handButtons.activeSelf);
        // ポンボタンも非表示になる
        Assert.IsFalse(ponButtonOBJ.activeSelf);
        // CPUが出す手を決める
        mockEnemyHand.Verify(e => e.PickHand(), Times.Once);
        // オブザーバーに通知を送る
        mockNotify.Verify(m => m.SetTextNotify("相手はグーを選びました"), Times.Once);
        // じゃんけんの勝敗判定処理が呼ばれる
        mockLogicJyanken.Verify(l => l.Judge(Value.Hand.Scissors, Value.Hand.Stone), Times.Once);
        // オブザーバーに通知を送る
        mockNotify.Verify(m => m.SetTextNotify("あなたの負けです"), Times.Once);
    }

}
