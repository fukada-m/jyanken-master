using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HandTest
{
    Hand _hand = new Hand();

    [Test]
    public void ConvertSignToJapanese_Convert()
    {
        var result = _hand.ConvertHandToJapanese(Value.Hand.Stone);
        Assert.AreEqual("�O�[", result);

        result = _hand.ConvertHandToJapanese(Value.Hand.Scissors);
        Assert.AreEqual("�`���L", result);

        result = _hand.ConvertHandToJapanese(Value.Hand.Paper);
        Assert.AreEqual("�p�[", result);
    }

    [TestCase(Value.Hand.Stone)]
    [TestCase(Value.Hand.Paper)]
    [TestCase(Value.Hand.Scissors)]

    public void Current_SetAndGet(Value.Hand hand)
    {
        _hand.Current = hand;
        Assert.AreEqual(_hand.Current, hand);
    }
}
