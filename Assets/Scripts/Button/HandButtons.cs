using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    IHand hand;

    void Start()
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        var handButtons = objects.FirstOrDefault(o => o.name == "HandButtons");
        hand = handButtons.GetComponent<Hand>();
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
