using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    GameObject _ponButton;
    IObserver _messageText;
    Notify _notify;
    public virtual PlayerHand PlayerHand {  get; set; }

    void Start()
    {
        _notify = new Notify();
        _messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        _notify.AddObserver(_messageText);
    }

    // �e�X�g�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject p, IObserver o, Notify n, PlayerHand ph)
    {
        _ponButton = p;
        _messageText = o;
        _notify = n;
        PlayerHand = ph;
    }



    // �v���C���[���O�[��I��
    public void OnClickStoneButton()
    {
        PlayerHand.Current = Value.Hand.Stone;
        SetHand();
        _ponButton.SetActive(true);
    }

    // �v���C���[���p�[��I��
    public void OnClickPaperButton()
    {
        PlayerHand.Current = Value.Hand.Paper;
        SetHand();
        _ponButton.SetActive(true);
    }

    // �v���C���[���`���L��I��
    public void OnClickScissorsButton()
    {
        PlayerHand.Current = Value.Hand.Scissors;
        SetHand();
        _ponButton.SetActive(true);
    }

    void SetHand()
    {
        var text = $"���Ȃ���{PlayerHand.ConvertHandToJapanese()}��I��ł��܂�";
        _notify.SetTextNotify(text);
    }
}
