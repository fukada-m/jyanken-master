using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    GameObject _ponButton;
    IObserver _messageText;
    Notify _notify;
    public virtual IHand Hand {  get; set; }

    void Start()
    {
        _notify = new Notify();
        _messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        _notify.AddObserver(_messageText);
    }

    // �e�X�g�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject p, IObserver o, Notify n, Hand s)
    {
        _ponButton = p;
        _messageText = o;
        _notify = n;
        Hand = s;
    }



    // �v���C���[���O�[��I��
    public void OnClickStoneButton()
    {
        Hand.Current = Value.Hand.Stone;
        SetHand(Hand);
        _ponButton.SetActive(true);
    }

    // �v���C���[���p�[��I��
    public void OnClickPaperButton()
    {
        Hand.Current = Value.Hand.Paper;
        SetHand(Hand);
        _ponButton.SetActive(true);
    }

    // �v���C���[���`���L��I��
    public void OnClickScissorsButton()
    {
        Hand.Current = Value.Hand.Scissors;
        SetHand(Hand);
        _ponButton.SetActive(true);
    }

    void SetHand(IHand Hand)
    {
        var text = $"���Ȃ���{Hand.ConvertHandToJapanese(Hand.Current)}��I��ł��܂�";
        _notify.SetTextNotify(text);
    }
}
