using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicJyankenTest
{
 

    // �������̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Stone)]
    public void LogicJyankenTestDraw(GameManager.Sign myself, GameManager.Sign enemy)
    {
        
        var result = LogicJyanken.Judge(myself, enemy);
        // �������̎���0
        Assert.AreEqual(result, "draw");
    }

    // ���������Ƃ��̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Scissors)]
    public void LogicJyankenTestWin(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        // �������̎���0
        Assert.AreEqual(result, "win");
    }

    // ������������Ƃ��̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Paper)]
    public void LogicJyankenTestLose(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        // �������̎���0
        Assert.AreEqual(result, "lose");
    }

}
