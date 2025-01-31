using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LogicJyankenTest
{
 

    // あいこのテスト
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Stone)]
    public void LogicJyankenTestDraw(GameManager.Sign myself, GameManager.Sign enemy)
    {
        
        var result = LogicJyanken.Judge(myself, enemy);
        // あいこの時は0
        Assert.AreEqual(result, "draw");
    }

    // 自分が勝つときのテスト
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Scissors)]
    public void LogicJyankenTestWin(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        // あいこの時は0
        Assert.AreEqual(result, "win");
    }

    // 自分が負けるときのテスト
    [TestCase(GameManager.Sign.Stone, GameManager.Sign.Paper)]
    public void LogicJyankenTestLose(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var result = LogicJyanken.Judge(myself, enemy);
        // あいこの時は0
        Assert.AreEqual(result, "lose");
    }

}
