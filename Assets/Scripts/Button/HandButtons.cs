using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    Hand hand;
    // プレイヤーがグーを選んだ
    public void onClickStoneButton()
    {
        hand.SetCrurrent(GameManager.Sign.Stone);
    }

    // プレイヤーがパーを選んだ
    public void onClickPaperButton()
    {
        hand.SetCrurrent(GameManager.Sign.Paper);

    }

    // プレイヤーがチョキを選んだ
    public void onClickScissorsButton()
    {
        hand.SetCrurrent(GameManager.Sign.Scissors);

    }
}
