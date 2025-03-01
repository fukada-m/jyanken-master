using UnityEngine;

public abstract class Hand
{
    public virtual Value.Hand Current { get; set; }

    public virtual string ConvertHandToJapanese(Value.Hand h)
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
