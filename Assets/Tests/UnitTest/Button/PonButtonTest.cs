using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class PonButtonTest
{
    GameObject handButtons;
    PonButton ponButton;
    Mock<ILogicJyanken> mockLogicJyanken;
    Mock<IEnemyHand> mockEnemyHand;

    [SetUp]
    public void PonButtonSetUp()
    {
        handButtons = new GameObject("handButtons");
        ponButton = new GameObject().AddComponent<PonButton>();
        mockLogicJyanken = new Mock<ILogicJyanken>();
        mockEnemyHand = new Mock<IEnemyHand>();
        var jyankenResult = new JyankenResult();
        mockEnemyHand.Setup(s => s.PickHand()).Returns(Sign.Hand.Stone);

        typeof(PonButton)
           .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
           .SetValue(ponButton, handButtons);
        typeof(PonButton)
           .GetField("jyankenResult", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
           .SetValue(ponButton, jyankenResult);
        typeof(PonButton)
            .GetField("logicJyanken", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(ponButton, mockLogicJyanken.Object);
        typeof(PonButton)
           .GetField("enemyHand", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
           .SetValue(ponButton, mockEnemyHand.Object);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void OnClickButton_JyankenJudge()
    {
        ponButton.OnClickButton();
        // ハンドボタンズは非表示になる
        Assert.IsFalse(handButtons.activeSelf);
        mockEnemyHand.Verify(e => e.PickHand(), Times.Once);
        // じゃんけんの判定処理が呼ばれたか確認
         mockLogicJyanken.Verify(l => l.Judge(Sign.Hand.Scissors, Sign.Hand.Stone), Times.Once);
    }

}
