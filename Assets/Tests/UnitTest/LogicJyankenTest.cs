using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicJyankenTest
{
    ILogicJyanken logicJyanken;

    [SetUp]
    public void LogicJyankenSetup()
    {
        logicJyanken = new LogicJyanken();
    }

    // あいこのテスト
    [TestCase(Sign.Hand.Stone, Sign.Hand.Stone)]
    [TestCase(Sign.Hand.Paper, Sign.Hand.Paper)]
    [TestCase(Sign.Hand.Scissors, Sign.Hand.Scissors)]

    public void LogicJyankenTestDraw(Sign.Hand myself, Sign.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Result.ResultEnum.Draw, result);
    }

    // 自分が勝つときのテスト
    [TestCase(Sign.Hand.Stone, Sign.Hand.Scissors)]
    [TestCase(Sign.Hand.Scissors, Sign.Hand.Paper)]
    [TestCase(Sign.Hand.Paper, Sign.Hand.Stone)]

    public void LogicJyankenTestWin(Sign.Hand myself, Sign.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Result.ResultEnum.WIn, result);
    }

    // 自分が負けるときのテスト
    [TestCase(Sign.Hand.Stone, Sign.Hand.Paper)]
    [TestCase(Sign.Hand.Scissors, Sign.Hand.Stone)]
    [TestCase(Sign.Hand.Paper, Sign.Hand.Scissors)]
    public void LogicJyankenTestLose(Sign.Hand myself, Sign.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Result.ResultEnum.Lose, result);
    }

}
