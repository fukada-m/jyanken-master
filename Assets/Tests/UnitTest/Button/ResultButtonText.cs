using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ResultButtonText
{
    GameObject resultButtonOBJ;
    ResultButton resultButton;
    Mock<INotify> mockNotify;
    Mock<IResult> mockResult;

    [SetUp]
    public void SetUp()
    {
        resultButtonOBJ = new GameObject("ResultButton");
        resultButton = resultButtonOBJ.AddComponent<ResultButton>();
        mockNotify = new Mock<INotify>();
        mockResult = new Mock<IResult>();
        mockResult.Setup(m => m.ConvertResultToJapanese(mockResult.Object.Current)).Returns("����");
        resultButton.Initialize(resultButtonOBJ, mockNotify.Object, mockResult.Object);
    }

    [Test]
    public void OnClickButton_ShowResult()
    {
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // �I�u�U�[�o�[�Ɍ��ʂ𑗂�
        mockNotify.Verify(m => m.SetTextNotify("���Ȃ��̕����ł�"));
        // Result�{�^������\���ɂȂ�
        Assert.IsFalse(resultButtonOBJ.activeSelf);
    }
}
