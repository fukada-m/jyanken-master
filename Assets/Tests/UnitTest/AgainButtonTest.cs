using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AgainButtonTest
{
    AgainButton againButton;
    GameObject againButtonOBJ;
    GameObject handButtons;
    GameObject endButtonOBJ;
    Mock<Notify> mockNotify;


    [SetUp]
    public void SetUp()
    {
        againButton = new AgainButton();
        againButtonOBJ = new GameObject();
        handButtons = new GameObject();
        // 初期状態は非表示
        handButtons.SetActive(false);
        endButtonOBJ = new GameObject();
        mockNotify = new Mock<Notify>();
        againButton.Initialize(handButtons, againButtonOBJ, endButtonOBJ, mockNotify.Object);
    }

    [Test]
    public void OnClickButton_Restart()
    {
        againButton.OnClickButton();
        // ハンドボタンズを表示
        Assert.IsTrue(handButtons.activeSelf);
        // 自身を非表示
        Assert.IsFalse(againButtonOBJ.activeSelf);
        // エンドボタンを非表示
        Assert.IsFalse(endButtonOBJ.activeSelf);
        // テキストメッセージを"何の手を出すか決めてください"に変更
        mockNotify.Verify(m => m.SetTextNotify("何の手を出すか決めてください"), Times.Once);
    }


}
