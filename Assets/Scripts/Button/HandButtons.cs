using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    Notify _notify;
    ISign _sign;

    void Start()
    {
        _sign = new Sign();
        _notify = new Notify();
    }

    // �e�X�g�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(Notify n, ISign s)
    {
        _notify = n;
        _sign = s;
    }

    // �v���C���[���O�[��I��
    public void OnClickStoneButton()
    {
        _sign.Current = Sign.Hand.Stone;
        SetHand(_sign);
    }

    // �v���C���[���p�[��I��
    public void OnClickPaperButton()
    {
        _sign.Current = Sign.Hand.Paper;
        SetHand(_sign);
    }

    // �v���C���[���`���L��I��
    public void OnClickScissorsButton()
    {
        _sign.Current = Sign.Hand.Scissors;
        SetHand(_sign);
    }

    void SetHand(ISign sign)
    {
        var text = $"���Ȃ���{_sign.ConvertHandToJapanese(sign.Current)}��I��ł��܂�";
        _notify.SetTextNotify(text);
    }
}
