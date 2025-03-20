using UnityEngine;

public class LogicJyanken : ILogicJyanken
{
    public Value.Result Judge(Value.Hand myself, Value.Hand enemy)
    {
        var stone = Value.Hand.Stone;
        var paper = Value.Hand.Paper;
        var scissors = Value.Hand.Scissors;

        // あいこのロジック
        if (myself == enemy) return Value.Result.Draw;

        // 勝つときのロジック
        if (myself == paper && enemy == stone) return Value.Result.Win;
        if (myself == stone && enemy == scissors) return Value.Result.Win;
        if (myself == scissors && enemy == paper) return Value.Result.Win;

        // 負けるときのロジック
        if (myself == scissors && enemy == stone) return Value.Result.Lose;
        if (myself == paper && enemy == scissors) return Value.Result.Lose;
        if (myself == stone && enemy == paper) return Value.Result.Lose;

        return Value.Result.Error;

    }
}
