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
    [TestCase(Value.Hand.Stone, Value.Hand.Stone)]
    [TestCase(Value.Hand.Paper, Value.Hand.Paper)]
    [TestCase(Value.Hand.Scissors, Value.Hand.Scissors)]

    public void LogicJyankenTestDraw(Value.Hand myself, Value.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Value.Result.Draw, result);
    }

    // 自分が勝つときのテスト
    [TestCase(Value.Hand.Stone, Value.Hand.Scissors)]
    [TestCase(Value.Hand.Scissors, Value.Hand.Paper)]
    [TestCase(Value.Hand.Paper, Value.Hand.Stone)]

    public void LogicJyankenTestWin(Value.Hand myself, Value.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Value.Result.Win, result);
    }

    // 自分が負けるときのテスト
    [TestCase(Value.Hand.Stone, Value.Hand.Paper)]
    [TestCase(Value.Hand.Scissors, Value.Hand.Stone)]
    [TestCase(Value.Hand.Paper, Value.Hand.Scissors)]
    public void LogicJyankenTestLose(Value.Hand myself, Value.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Value.Result.Lose, result);
    }

}
