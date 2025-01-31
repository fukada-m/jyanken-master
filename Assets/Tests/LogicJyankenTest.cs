using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicJyankenTest
{
 

    // �������̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Stone)]
    public void LogicJyankenTestDraw(string myself, string enemy)
    {
        
        var result = LogicJyanken.Judge(myself, enemy);
        // �������̎���0
        Assert.AreEqual(result, "draw");
    }

    // ���������Ƃ��̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Scissors)]
    public void LogicJyankenTestWin(string myself, string enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        // �������̎���0
        Assert.AreEqual(result, "win");
    }

    // ������������Ƃ��̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Paper)]
    public void LogicJyankenTestLose(string myself, string enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        // �������̎���0
        Assert.AreEqual(result, "lose");
    }

}
