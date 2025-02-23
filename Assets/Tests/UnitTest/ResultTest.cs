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
        var str = result.ConvertResultToJapanese(Value.Result.WIn);
        Assert.AreEqual("èüÇø", str);

        str = result.ConvertResultToJapanese(Value.Result.Lose);
        Assert.AreEqual("ïâÇØ", str);

        str = result.ConvertResultToJapanese(Value.Result.Draw);
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
