using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PonButtonTest
{
    GameObject handButtons;
    PonButton ponButton;

    [SetUp]
    public void PonButtonSetUp()
    {
        handButtons = new GameObject("handButtons");
        ponButton = new GameObject().AddComponent<PonButton>();

        typeof(PonButton)
           .GetField("handButtons", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
           .SetValue(ponButton, handButtons);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void onClickButton_JyankenJudge()
    {
        ponButton.onClickButton();
        // ハンドボタンズは非表示になる
        Assert.IsFalse(handButtons.activeSelf);
        
    }

}
