using System.Collections;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ResultButtonTest
{
    GameObject resultButtonOBJ;
    GameObject endButtonOBJ;
    ResultButton resultButton;
    Mock<INotify> mockNotify;
    Mock<IResult> mockResult;

    [SetUp]
    public void SetUp()
    {
        resultButtonOBJ = new GameObject("ResultButton");
        endButtonOBJ = new GameObject("EndButton");
        resultButton = resultButtonOBJ.AddComponent<ResultButton>();
        mockNotify = new Mock<INotify>();
        mockResult = new Mock<IResult>();
        mockResult.Setup(m => m.ConvertResultToJapanese()).Returns("����");
        resultButton.Initialize(resultButtonOBJ, endButtonOBJ, mockNotify.Object, mockResult.Object);
    }

    [Test]
    public void OnClickButton_ShowResult()
    {
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // �I�u�U�[�o�[�Ɍ��ʂ𑗂�
        mockNotify.Verify(m => m.SetTextNotify("���ʂ͕����ł�"));
        // Result�{�^������\���ɂȂ�
        Assert.IsFalse(resultButtonOBJ.activeSelf);
        // End�{�^�����\�������
        Assert.IsTrue(endButtonOBJ.activeSelf);
    }
}
