using UnityEngine;

// プレイヤーがどの手を出しているかについて責任を持つクラス

public class Hand :  Notify
{
    ISign _sign;
    public Hand(ISign i)
    {
        _sign = i;
    }

    public  Sign.Hand Current { get; private set; }
    public virtual void SetCurrent(Sign.Hand h)
    {
        Current = h;
    }

    public override void GenerateText()
    {
        var currentHand = _sign.ConvertHandToJapanese(Current);
        Text = $"あなたは{currentHand}を選んでいます";
        NotifyObservers();
    }
}
