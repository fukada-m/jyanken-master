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
    IObserver messageText;
    INotify notify;
    IResult result;
    TMP_Text text;

    [SetUp]
    public void SetUp()
    {
        resultButtonOBJ = new GameObject("ResultButton");
        endButtonOBJ = new GameObject("EndButton");
        resultButton = resultButtonOBJ.AddComponent<ResultButton>();
        messageText = new GameObject().AddComponent<ObserverText>();
        notify = new Notify();
        result = new Result();
        text = new GameObject().AddComponent<TextMeshProUGUI>();
        resultButton.Initialize(resultButtonOBJ, endButtonOBJ, notify, result);
        messageText.Initialize(text);
        notify.AddObserver(messageText);
    }

    [Test]
    public void OnclickButton_ShowResult()
    {
        resultButton.OnClickButton();
        result.Current = Value.Result.WIn;
        Assert.AreEqual(text.text, "���ʂ͏����ł�");
        Assert.IsFalse(resultButtonOBJ.activeSelf);
    }

}
