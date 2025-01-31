using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    Hand hand;
    // �v���C���[���O�[��I��
    public void onClickStoneButton()
    {
        hand.SetCrurrent(GameManager.Sign.Stone);
    }

    // �v���C���[���p�[��I��
    public void onClickPaperButton()
    {
        hand.SetCrurrent(GameManager.Sign.Paper);

    }

    // �v���C���[���`���L��I��
    public void onClickScissorsButton()
    {
        hand.SetCrurrent(GameManager.Sign.Scissors);

    }
}
