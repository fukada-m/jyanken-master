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
            Sign.Hand.Stone => "�O�[",
            Sign.Hand.Scissors => "�`���L",
            Sign.Hand.Paper => "�p�[",
            _ => "�G���[" // �f�t�H���g�P�[�X
        };
    }
}
