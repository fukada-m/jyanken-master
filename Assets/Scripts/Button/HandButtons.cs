using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    // TODO Notify型を使えるように直す
    Hand _hand;
    void Start()
    {
        _hand = new Hand(new Sign());
    }

    public void Initialize(Hand h)
    {
        _hand = h;
    }

    // プレイヤーがグーを選んだ
    public void OnClickStoneButton()
    {
        _hand.SetCurrent(Sign.Hand.Stone);
        _hand.GenerateText();
    }

    // プレイヤーがパーを選んだ
    public void OnClickPaperButton()
    {
        _hand.SetCurrent(Sign.Hand.Paper);
        _hand.GenerateText();
    }

    // プレイヤーがチョキを選んだ
    public void OnClickScissorsButton()
    {
        _hand.SetCurrent(Sign.Hand.Scissors);
        _hand.GenerateText();
    }
}
