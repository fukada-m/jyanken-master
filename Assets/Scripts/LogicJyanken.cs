using UnityEngine;

public class LogicJyanken
{
    public static string Judge(GameManager.Sign myself, GameManager.Sign enemy)
    {
        var stone = GameManager.Sign.Stone;
        var paper = GameManager.Sign.Paper;
        var scissors = GameManager.Sign.Scissors;

        // �������̃��W�b�N
        if (myself == enemy) return "draw";

        //���Ƃ��̃��W�b�N
        if (myself == paper && enemy == stone) return "win";
        if (myself == stone && enemy == scissors) return "win";
        if (myself == scissors && enemy == paper) return "win";

        //�c��̃p�^�[���͕���
        return "lose";
    } 
}
