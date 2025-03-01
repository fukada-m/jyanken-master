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
