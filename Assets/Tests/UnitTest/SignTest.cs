using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SignTest
{
    Sign sign = new Sign();

    [Test]
    public void ConvertSignToJapanese_Convert()
    {
        var result = sign.ConvertHandToJapanese(Sign.Hand.Stone);
        Assert.AreEqual("�O�[", result);

        result = sign.ConvertHandToJapanese(Sign.Hand.Scissors);
        Assert.AreEqual("�`���L", result);

        result = sign.ConvertHandToJapanese(Sign.Hand.Paper);
        Assert.AreEqual("�p�[", result);
    }
}
