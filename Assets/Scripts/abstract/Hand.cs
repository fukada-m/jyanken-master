using UnityEngine;

public abstract class Hand
{
    public virtual Value.Hand Current { get; set; }

    public virtual string ConvertHandToJapanese(Value.Hand h)
    {
        return h switch
        {
            Value.Hand.Stone => "�O�[",
            Value.Hand.Scissors => "�`���L",
            Value.Hand.Paper => "�p�[",
            _ => "�G���[" // �f�t�H���g�P�[�X
        };
    }
}
