using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ResultButtonTest
{
    GameObject resultButtonOBJ;
    GameObject endButtonOBJ;
    GameObject winCountTextOBJ;
    ResultButton resultButton;
    Mock<INotify> mockNotify;
    Mock<IResult> mockResult;

    [SetUp]
    public void SetUp()
    {
        resultButtonOBJ = new GameObject("ResultButton");
        endButtonOBJ = new GameObject("EndButton");
        winCountTextOBJ = new GameObject("WinCountText");
        // 最初はWinCountTextは非表示
        winCountTextOBJ.SetActive(false);
        resultButton = resultButtonOBJ.AddComponent<ResultButton>();
        mockNotify = new Mock<INotify>();
        mockResult = new Mock<IResult>();
        mockResult.Setup(m => m.ConvertResultToJapanese()).Returns("負け");
        resultButton.Initialize(resultButtonOBJ, endButtonOBJ, winCountTextOBJ, mockNotify.Object, mockResult.Object);
    }

    [Test]
    public void OnClickButton_ShowResult()
    {
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // オブザーバーに結果を送る
        mockNotify.Verify(m => m.SetTextNotify("結果は負けです"));
        // Resultボタンが非表示になる
        Assert.IsFalse(resultButtonOBJ.activeSelf);
        // WinCountが表示される
        Assert.IsTrue(winCountTextOBJ.activeSelf);
        // Endボタンが表示される
        Assert.IsTrue(endButtonOBJ.activeSelf);
    }
}
