using UnityEngine;
using System.Collections.Generic;
// プレイヤーがどの手を出しているかについて責任を持つクラス

public class Hand :  Notify
{
    // プレイヤーの手の状態を表す
    public GameManager.Sign Current { get; private set; }

    public void SetCurrent(GameManager.Sign sign)
    {
        Current = sign;
        GenerateText();
        NotifyObservers();
    }

    void GenerateText()
    {
        Text = $"あなたは{Current}を選んでいます";
    }
   
}
