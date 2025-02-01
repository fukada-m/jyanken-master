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


    // �v���C���[���O�[��I��
    public void onClickStoneButton()
    {
        hand.SetCurrent(GameManager.Sign.Stone);
    }

    // �v���C���[���p�[��I��
    public void onClickPaperButton()
    {
        hand.SetCurrent(GameManager.Sign.Paper);

    }

    // �v���C���[���`���L��I��
    public void onClickScissorsButton()
    {
        hand.SetCurrent(GameManager.Sign.Scissors);

    }
}
