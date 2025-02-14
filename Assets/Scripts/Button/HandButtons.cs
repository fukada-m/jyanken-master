using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    // TODO Notify�^���g����悤�ɒ���
    Hand _hand;
    void Start()
    {
        _hand = new Hand(new Sign());
    }

    public void Initialize(Hand h)
    {
        _hand = h;
    }

    // �v���C���[���O�[��I��
    public void OnClickStoneButton()
    {
        _hand.SetCurrent(Sign.Hand.Stone);
        _hand.GenerateText();
    }

    // �v���C���[���p�[��I��
    public void OnClickPaperButton()
    {
        _hand.SetCurrent(Sign.Hand.Paper);
        _hand.GenerateText();
    }

    // �v���C���[���`���L��I��
    public void OnClickScissorsButton()
    {
        _hand.SetCurrent(Sign.Hand.Scissors);
        _hand.GenerateText();
    }
}
