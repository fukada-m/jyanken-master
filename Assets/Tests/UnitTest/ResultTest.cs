using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ResultTest
{
    Result result = new Result();

    // A Test behaves as an ordinary method
    [Test]
    public void ConvertResultToJapanese_Convert()
    {
        result.Current = Value.Result.WIn;
        var str = result.ConvertResultToJapanese();
        Assert.AreEqual("èüÇø", str);

        result.Current = Value.Result.Lose;
        str = result.ConvertResultToJapanese();
        Assert.AreEqual("ïâÇØ", str);

        result.Current = Value.Result.Draw;
        str = result.ConvertResultToJapanese();
        Assert.AreEqual("Ç†Ç¢Ç±", str);
    }

    [TestCase(Value.Result.WIn)]
    [TestCase(Value.Result.Lose)]
    [TestCase(Value.Result.Draw)]
    public void Current_SetAndGet(Value.Result r)
    {
        result.Current = r;
        Assert.AreEqual(result.Current, r);
    }

}
