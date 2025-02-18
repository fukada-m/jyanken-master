using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    GameObject _ponButton;
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
    public void Initialize(GameObject p, IObserver o, Notify n, ISign s)
    {
        _ponButton = p;
        _messageText = o;
        _notify = n;
        _sign = s;
    }

    // �v���C���[���O�[��I��
    public void OnClickStoneButton()
    {
        _sign.Current = Sign.Hand.Stone;
        SetHand(_sign);
        _ponButton.SetActive(true);
    }

    // �v���C���[���p�[��I��
    public void OnClickPaperButton()
    {
        _sign.Current = Sign.Hand.Paper;
        SetHand(_sign);
        _ponButton.SetActive(true);
    }

    // �v���C���[���`���L��I��
    public void OnClickScissorsButton()
    {
        _sign.Current = Sign.Hand.Scissors;
        SetHand(_sign);
        _ponButton.SetActive(true);
    }

    void SetHand(ISign sign)
    {
        var text = $"���Ȃ���{_sign.ConvertHandToJapanese(sign.Current)}��I��ł��܂�";
        _notify.SetTextNotify(text);
    }
}
