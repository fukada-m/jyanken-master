using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    IObserver _messageText;
    Notify _notify;
    ISign _sign;

    void Start()
    {
        _sign = new Sign();
        _notify = new Notify();
        _messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        _notify.AddObserver(_messageText);
    }

    // �e�X�g�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(IObserver o, Notify n, ISign s)
    {
        _messageText = o;
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
