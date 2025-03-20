using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class IntegResultButton
{
    ResultButton resultButton;
    GameObject resultButtonOBJ;
    GameObject endButtonOBJ;
    GameObject winCountTextOBJ;
    GameObject againButtonOBJ;
    IObserver messageText;
    IObserver winCountText;
    INotify messageNotify;
    INotify winCountNotify;
    IResult result;
    TMP_Text text1;
    TMP_Text text2;

    [SetUp]
    public void SetUp()
    {
        resultButtonOBJ = new GameObject("ResultButton");
        endButtonOBJ = new GameObject("EndButton");
        winCountTextOBJ = new GameObject("WinCountText");
        againButtonOBJ = new GameObject();
        // ç≈èâÇÕWinCountTextÇÕîÒï\é¶
        winCountTextOBJ.SetActive(false);
        resultButton = resultButtonOBJ.AddComponent<ResultButton>();
        messageText = new GameObject().AddComponent<ObserverText>();
        winCountText = new GameObject().AddComponent<ObserverText>();
        messageNotify = new Notify();
        winCountNotify = new Notify();
        result = new Result();
        text1 = new GameObject().AddComponent<TextMeshProUGUI>();
        text2 = new GameObject().AddComponent<TextMeshProUGUI>();
        resultButton.Initialize(resultButtonOBJ, endButtonOBJ,winCountTextOBJ, againButtonOBJ, messageNotify, winCountNotify, result);
        messageText.Initialize(text1);
        winCountText.Initialize(text2);
        messageNotify.AddObserver(messageText);
        winCountNotify.AddObserver(winCountText);
    }

    [Test]
    public void OnclickButton_ShowResult()
    {
        resultButton.OnClickButton();
        result.Current = Value.Result.Win;
        Assert.AreEqual(text1.text, "åãâ ÇÕèüÇøÇ≈Ç∑");
        Assert.AreEqual(text2.text, "òAèüêîÅF1");
        Assert.IsFalse(resultButtonOBJ.activeSelf);
        Assert.IsTrue(winCountTextOBJ.activeSelf);
        Assert.IsTrue(againButtonOBJ.activeSelf);
    }

}
