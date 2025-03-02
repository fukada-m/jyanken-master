using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerHandTest
{
    Hand _hand = new PlayerHand();

    [Test]
    public void ConvertSignToJapanese_Convert()
    {
        _hand.Current = Value.Hand.Stone;
        var result = _hand.ConvertHandToJapanese();
        Assert.AreEqual("グー", result);

        _hand.Current = Value.Hand.Scissors;
        result = _hand.ConvertHandToJapanese();
        Assert.AreEqual("チョキ", result);

        _hand.Current = Value.Hand.Paper;
        result = _hand.ConvertHandToJapanese();
        Assert.AreEqual("パー", result);
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
