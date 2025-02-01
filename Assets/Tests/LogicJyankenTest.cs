using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicJyankenTest
{
 

    // �������̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Stone)]
    [TestCase(GameManager.Sign.Paper, GameManager.Sign.Paper)]
    [TestCase(GameManager.Sign.Scissors, GameManager.Sign.Scissors)]

    public void LogicJyankenTestDraw(GameManager.Sign myself, GameManager.Sign enemy)
    {
        
        var result = LogicJyanken.Judge(myself, enemy);
        Assert.AreEqual(GameManager.Result.Draw, result);
    }

    // ���������Ƃ��̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Scissors)]
    [TestCase(GameManager.Sign.Scissors, GameManager.Sign.Paper)]
    [TestCase(GameManager.Sign.Paper, GameManager.Sign.Stone)]

    public void LogicJyankenTestWin(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        Assert.AreEqual(GameManager.Result.WIn, result);
    }

    // ������������Ƃ��̃e�X�g
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Paper)]
    [TestCase(GameManager.Sign.Scissors, GameManager.Sign.Stone)]
    [TestCase(GameManager.Sign.Paper, GameManager.Sign.Scissors)]
    public void LogicJyankenTestLose(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        Assert.AreEqual(GameManager.Result.Lose, result);
    }

}
