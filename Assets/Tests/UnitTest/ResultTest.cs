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
        var str = result.ConvertResultToJapanese(Result.ResultEnum.WIn);
        Assert.AreEqual("Ÿ‚¿", str);

        str = result.ConvertResultToJapanese(Result.ResultEnum.Lose);
        Assert.AreEqual("•‰‚¯", str);

        str = result.ConvertResultToJapanese(Result.ResultEnum.Draw);
        Assert.AreEqual("‚ ‚¢‚±", str);
    }

    [TestCase(Result.ResultEnum.WIn)]
    [TestCase(Result.ResultEnum.Lose)]
    [TestCase(Result.ResultEnum.Draw)]
    public void Current_SetAndGet(Result.ResultEnum r)
    {
        result.Current = r;
        Assert.AreEqual(result.Current, r);
    }

}
