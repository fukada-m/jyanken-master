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
        // �ŏ���WinCountText�͔�\��
        winCountTextOBJ.SetActive(false);
        // �ŏ��͂�����x�{�^���͔�\��
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
        mockResult.Setup(m => m.ConvertResultToJapanese()).Returns("����");
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // �I�u�U�[�o�[�Ɍ��ʂ𑗂�
        mockMessageNotify.Verify(m => m.SetTextNotify("���ʂ͕����ł�"));
        mockWinCountNotify.Verify(m => m.SetTextNotify("�A�����F0"));
        // Result�{�^������\���ɂȂ�
        Assert.IsFalse(resultButtonOBJ.activeSelf);
        // WinCount���\�������
        Assert.IsTrue(winCountTextOBJ.activeSelf);
        // End�{�^�����\�������
        Assert.IsTrue(endButtonOBJ.activeSelf);
        // Again�{�^�����\�������
        Assert.IsTrue(againButtonOBJ.activeSelf);
    }
    public void OnClickButton_ShowResult_Lose()
    {
        mockResult.Setup(m => m.Current).Returns(Value.Result.Lose);
        mockResult.Setup(m => m.ConvertResultToJapanese()).Returns("����");
        Assert.IsNotNull(resultButton);
        resultButton.OnClickButton();
        // �I�u�U�[�o�[�Ɍ��ʂ𑗂�
        mockMessageNotify.Verify(m => m.SetTextNotify("���ʂ͕����ł�"));
        mockWinCountNotify.Verify(m => m.SetTextNotify("�A�����F0"));
        // Result�{�^������\���ɂȂ�
        Assert.IsFalse(resultButtonOBJ.activeSelf);
        // WinCount���\�������
        Assert.IsTrue(winCountTextOBJ.activeSelf);
        // End�{�^�����\�������
        Assert.IsTrue(endButtonOBJ.activeSelf);
        // Again�{�^�����\�������
        Assert.IsTrue(againButtonOBJ.activeSelf);
    }
}
