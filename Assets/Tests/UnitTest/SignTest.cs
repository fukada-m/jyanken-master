using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SignTest
{
    Sign _sign = new Sign();

    [Test]
    public void ConvertSignToJapanese_Convert()
    {
        var result = _sign.ConvertHandToJapanese(Sign.Hand.Stone);
        Assert.AreEqual("グー", result);

        result = _sign.ConvertHandToJapanese(Sign.Hand.Scissors);
        Assert.AreEqual("チョキ", result);

        result = _sign.ConvertHandToJapanese(Sign.Hand.Paper);
        Assert.AreEqual("パー", result);
    }

    [TestCase(Sign.Hand.Stone)]
    [TestCase(Sign.Hand.Paper)]
    [TestCase(Sign.Hand.Scissors)]

    public void Current_SetAndGet(Sign.Hand hand)
    {
        _sign.Current = hand;
        Assert.AreEqual(_sign.Current, hand);
    }
}
