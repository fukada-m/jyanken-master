using UnityEngine;

public class LogicJyanken : ILogicJyanken
{
    public Result.ResultEnum Judge(Sign.Hand myself, Sign.Hand enemy)
    {
        var stone = Sign.Hand.Stone;
        var paper = Sign.Hand.Paper;
        var scissors = Sign.Hand.Scissors;

        // �������̃��W�b�N
        if (myself == enemy) return Result.ResultEnum.Draw;

        // ���Ƃ��̃��W�b�N
        if (myself == paper && enemy == stone) return Result.ResultEnum.WIn;
        if (myself == stone && enemy == scissors) return Result.ResultEnum.WIn;
        if (myself == scissors && enemy == paper) return Result.ResultEnum.WIn;

        // ������Ƃ��̃��W�b�N
        if (myself == scissors && enemy == stone) return Result.ResultEnum.Lose;
        if (myself == paper && enemy == scissors) return Result.ResultEnum.Lose;
        if (myself == stone && enemy == paper) return Result.ResultEnum.Lose;

        return Result.ResultEnum.Error;

    }
}
