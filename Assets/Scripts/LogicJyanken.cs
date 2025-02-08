using UnityEngine;

public class LogicJyanken : ILogicJyanken
{
    public GameManager.Result Judge(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var stone = GameManager.Sign.Stone;
        var paper = GameManager.Sign.Paper;
        var scissors = GameManager.Sign.Scissors;

        // �������̃��W�b�N
        if (myself == enemy) return GameManager.Result.Draw;

        // ���Ƃ��̃��W�b�N
        if (myself == paper && enemy == stone) return GameManager.Result.WIn;
        if (myself == stone && enemy == scissors) return GameManager.Result.WIn;
        if (myself == scissors && enemy == paper) return GameManager.Result.WIn;

        // ������Ƃ��̃��W�b�N
        if (myself == scissors && enemy == stone) return GameManager.Result.Lose;
        if (myself == paper && enemy == scissors) return GameManager.Result.Lose;
        if (myself == stone && enemy == paper) return GameManager.Result.Lose;

        return GameManager.Result.Error;
    } 
}
