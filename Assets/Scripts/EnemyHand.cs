using UnityEngine;

public class EnemyHand : IEnemyHand
{
    Sign.Hand stone = Sign.Hand.Stone;
    Sign.Hand scissors = Sign.Hand.Scissors;
    Sign.Hand paper = Sign.Hand.Paper;

    // TODO ����CPU�̓O�[�����o���Ȃ�
    public Sign.Hand PickHand()
    {
        return stone;
    }
}
