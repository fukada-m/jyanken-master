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
