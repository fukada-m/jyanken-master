using UnityEngine;

public class Sign : ISign
{
    public enum Hand
    {
        Stone,
        Scissors,
        Paper,
        Error
    }

    public string ConvertHandToJapanese(Sign.Hand h)
    {
        return h switch
        {
            Sign.Hand.Stone => "グー",
            Sign.Hand.Scissors => "チョキ",
            Sign.Hand.Paper => "パー",
            _ => "エラー" // デフォルトケース
        };
    }
}
