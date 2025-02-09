using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    IHand hand;


    void Start()
    {
        hand = handButtons.GetComponent<IHand>();
    }


    // プレイヤーがグーを選んだ
    public void OnClickStoneButton()
    {
        hand.SetCurrent(GameManager.Sign.Stone);
    }

    // プレイヤーがパーを選んだ
    public void OnClickPaperButton()
    {
        hand.SetCurrent(GameManager.Sign.Paper);

    }

    // プレイヤーがチョキを選んだ
    public void OnClickScissorsButton()
    {
        hand.SetCurrent(GameManager.Sign.Scissors);

    }
}
