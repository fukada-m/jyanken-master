using UnityEngine;

public class Hand : IHand
{
    public Value.Hand Current { get; set; }

    public string ConvertHandToJapanese(Value.Hand h)
    {
        return h switch
        {
            Value.Hand.Stone => "グー",
            Value.Hand.Scissors => "チョキ",
            Value.Hand.Paper => "パー",
            _ => "エラー" // デフォルトケース
        };
    }
}
