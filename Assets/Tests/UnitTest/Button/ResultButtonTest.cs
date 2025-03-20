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
    GameObject againButtonOBJ;
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
        againButtonOBJ = new GameObject("AgainButton");
        // 最初はWinCountTextは非表示
        winCountTextOBJ.SetActive(false);
        // 最初はもう一度ボタンは非表示
        againButtonOBJ.SetActive(false);
        resultButton = resultButtonOBJ.AddComponent<ResultButton>();
        mockMessageNotify = new Mock<INotify>();
        mockWinCountNotify = new Mock<INotify>();
        mockResult = new Mock<IResult>();
        resultButton.Initialize(resultButtonOBJ, endButtonOBJ, winCountTextOBJ, againButtonOBJ, mockMessageNotify.Object, mockWinCountNotify.Object, mockResult.Object);
    }

    [Test]
    public void OnClickButton_ShowResult_Win()
    {
        mockResult.Setup(m => m.Current).Returns(Value.Result.Win);
        mockResult.Setup(m => m.ConvertResultToJapanese()).Returns("勝ち");
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // オブザーバーに結果を送る
        mockMessageNotify.Verify(m => m.SetTextNotify("結果は勝ちです"));
        mockWinCountNotify.Verify(m => m.SetTextNotify("連勝数：1"));
        ButtonDispTest();
    }
    public void OnClickButton_ShowResult_Lose()
    {
        mockResult.Setup(m => m.Current).Returns(Value.Result.Lose);
        mockResult.Setup(m => m.ConvertResultToJapanese()).Returns("負け");
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // オブザーバーに結果を送る
        mockMessageNotify.Verify(m => m.SetTextNotify("結果は負けです"));
        mockWinCountNotify.Verify(m => m.SetTextNotify("連勝数：0"));
        ButtonDispTest();
    }
    public void OnClickButton_ShowResult_Draw()
    {
        mockResult.Setup(m => m.Current).Returns(Value.Result.Draw);
        mockResult.Setup(m => m.ConvertResultToJapanese()).Returns("あいこ");
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // オブザーバーに結果を送る
        mockMessageNotify.Verify(m => m.SetTextNotify("結果はあいこです"));
        mockWinCountNotify.Verify(m => m.SetTextNotify("連勝数：0"));
        ButtonDispTest();
    }

    void ButtonDispTest()
    {
        // Resultボタンが非表示になる
        Assert.IsFalse(resultButtonOBJ.activeSelf);
        // WinCountが表示される
        Assert.IsTrue(winCountTextOBJ.activeSelf);
        // Endボタンが表示される
        Assert.IsTrue(endButtonOBJ.activeSelf);
        // Againボタンが表示される
        Assert.IsTrue(againButtonOBJ.activeSelf);

    }
}
