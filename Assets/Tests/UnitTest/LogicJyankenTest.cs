using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicJyankenTest
{
    LogicJyanken logicJyanken;
    [SetUp]
    public void LogicJyankenSetup()
    {
        logicJyanken = new LogicJyanken();
    }
    // �������̃e�X�g
    [TestCase(Sign.Hand.Stone, Sign.Hand.Stone)]
    [TestCase(Sign.Hand.Paper, Sign.Hand.Paper)]
    [TestCase(Sign.Hand.Scissors, Sign.Hand.Scissors)]

    public void LogicJyankenTestDraw(Sign.Hand myself, Sign.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(GameManager.Result.Draw, result);
    }

    // ���������Ƃ��̃e�X�g
    [TestCase(Sign.Hand.Stone, Sign.Hand.Scissors)]
    [TestCase(Sign.Hand.Scissors, Sign.Hand.Paper)]
    [TestCase(Sign.Hand.Paper, Sign.Hand.Stone)]

    public void LogicJyankenTestWin(Sign.Hand myself, Sign.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(GameManager.Result.WIn, result);
    }

    // ������������Ƃ��̃e�X�g
    [TestCase(Sign.Hand.Stone, Sign.Hand.Paper)]
    [TestCase(Sign.Hand.Scissors, Sign.Hand.Stone)]
    [TestCase(Sign.Hand.Paper, Sign.Hand.Scissors)]
    public void LogicJyankenTestLose(Sign.Hand myself, Sign.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(GameManager.Result.Lose, result);
    }

}
