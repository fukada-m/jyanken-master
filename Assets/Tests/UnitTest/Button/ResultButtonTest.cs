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
    GameObject messageTextOBJ;
    ResultButton resultButton;
    Mock<INotify> mockMessageNotify;
    Mock<INotify> mockWinCountNotify;
    Mock<IResult> mockResult;

    [SetUp]
    public void SetUp()
    {
        resultButtonOBJ = new GameObject("ResultButton");
        endButtonOBJ = new GameObject("EndButton");
        winCountTextOBJ = new GameObject("WinCountText");
        messageTextOBJ = new GameObject("MessageText");
        winCountTextOBJ.AddComponent<ObserverText>();
        messageTextOBJ.AddComponent<ObserverText>();
        // 最初はWinCountTextは非表示
        winCountTextOBJ.SetActive(false);
        resultButton = resultButtonOBJ.AddComponent<ResultButton>();
        mockMessageNotify = new Mock<INotify>();
        mockWinCountNotify = new Mock<INotify>();
        mockResult = new Mock<IResult>();
        mockResult.Setup(m => m.Current).Returns(Value.Result.Lose);
        mockResult.Setup(m => m.ConvertResultToJapanese()).Returns("負け");
        resultButton.Initialize(resultButtonOBJ, endButtonOBJ, winCountTextOBJ, mockMessageNotify.Object, mockWinCountNotify.Object, mockResult.Object);
    }

    [Test]
    public void OnClickButton_ShowResult()
    {
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // オブザーバーに結果を送る
        mockMessageNotify.Verify(m => m.SetTextNotify("結果は負けです"));
        mockWinCountNotify.Verify(m => m.SetTextNotify("連勝数：0"));
        // Resultボタンが非表示になる
        Assert.IsFalse(resultButtonOBJ.activeSelf);
        // WinCountが表示される
        Assert.IsTrue(winCountTextOBJ.activeSelf);
        // Endボタンが表示される
        Assert.IsTrue(endButtonOBJ.activeSelf);
    }
}
