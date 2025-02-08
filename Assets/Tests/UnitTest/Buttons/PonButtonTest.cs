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
        // ハンドボタンズは非表示になる
        Assert.IsFalse(handButtons.activeSelf);
        // じゃんけんの判定処理が呼ばれたか確認
         moqLogicJyanken.Verify(l => l.Judge(GameManager.Sign.Scissors, GameManager.Sign.Scissors), Times.Once);
        // messageをアップデートする
        
    }

}
