using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicJyankenTest
{
    // あいこのテスト
    [TestCase("グー", "グー")]
    public void LogicJyankenTestDraw(string myself, string enemy)
    {
        
        var result = LogicJyanken.Judge(myself, enemy);
        // あいこの時は0
        Assert.AreEqual(result, "draw");
    }

    // 自分が勝つときのテスト
    [TestCase("グー", "チョキ")]
    public void LogicJyankenTestWin(string myself, string enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        // あいこの時は0
        Assert.AreEqual(result, "win");
    }

    // 自分が負けるときのテスト
    [TestCase("グー", "パー")]
    public void LogicJyankenTestLose(string myself, string enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        // あいこの時は0
        Assert.AreEqual(result, "lose");
    }

}
