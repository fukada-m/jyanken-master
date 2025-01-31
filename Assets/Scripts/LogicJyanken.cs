using UnityEngine;

public class LogicJyanken
{
    public static string Judge(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var stone = GameManager.Sign.Stone;
        var paper = GameManager.Sign.Paper;
        var scissors = GameManager.Sign.Scissors;

        // あいこのロジック
        if (myself == enemy) return "draw";

        //勝つときのロジック
        if (myself == paper && enemy == stone) return "win";
        if (myself == stone && enemy == scissors) return "win";
        if (myself == scissors && enemy == paper) return "win";

        //残りのパターンは負け
        return "lose";
    } 
}
