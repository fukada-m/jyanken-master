using UnityEngine;

// �v���C���[���ǂ̎���o���Ă��邩�ɂ��ĐӔC�����N���X

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
        Text = $"���Ȃ���{currentHand}��I��ł��܂�";
        NotifyObservers();
    }
}
