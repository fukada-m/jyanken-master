using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    IHand hand;

    void Start()
    {
        hand = new GameObject("HandButtons").GetComponent<Hand>();
    }


    // プレイヤーがグーを選んだ
    public void onClickStoneButton()
    {
        hand.SetCurrent(GameManager.Sign.Stone);
    }

    // プレイヤーがパーを選んだ
    public void onClickPaperButton()
    {
        hand.SetCurrent(GameManager.Sign.Paper);

    }

    // プレイヤーがチョキを選んだ
    public void onClickScissorsButton()
    {
        hand.SetCurrent(GameManager.Sign.Scissors);

    }
}
