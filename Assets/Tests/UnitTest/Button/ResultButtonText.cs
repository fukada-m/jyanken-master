using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ResultButtonText
{
    ResultButton resultButton;
    Mock<Notify> mockNotify;

    [SetUp]
    public void SetUp()
    {
        resultButton = new GameObject().AddComponent<ResultButton>();
        mockNotify = new Mock<Notify>();
        resultButton.Initialize(mockNotify.Object);
    }

    [Test]
    public void OnClickButton_ShowResult()
    {
        resultButton.OnClickButton();
        // オブザーバーに結果を送る

    }
}
