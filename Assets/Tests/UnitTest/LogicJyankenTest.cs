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

    // �������̃e�X�g
    [TestCase(Value.Hand.Stone, Value.Hand.Stone)]
    [TestCase(Value.Hand.Paper, Value.Hand.Paper)]
    [TestCase(Value.Hand.Scissors, Value.Hand.Scissors)]

    public void LogicJyankenTestDraw(Value.Hand myself, Value.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Value.Result.Draw, result);
    }

    // ���������Ƃ��̃e�X�g
    [TestCase(Value.Hand.Stone, Value.Hand.Scissors)]
    [TestCase(Value.Hand.Scissors, Value.Hand.Paper)]
    [TestCase(Value.Hand.Paper, Value.Hand.Stone)]

    public void LogicJyankenTestWin(Value.Hand myself, Value.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Value.Result.Win, result);
    }

    // ������������Ƃ��̃e�X�g
    [TestCase(Value.Hand.Stone, Value.Hand.Paper)]
    [TestCase(Value.Hand.Scissors, Value.Hand.Stone)]
    [TestCase(Value.Hand.Paper, Value.Hand.Scissors)]
    public void LogicJyankenTestLose(Value.Hand myself, Value.Hand enemy)
    {
        var result = logicJyanken.Judge(myself, enemy);
        Assert.AreEqual(Value.Result.Lose, result);
    }

}
