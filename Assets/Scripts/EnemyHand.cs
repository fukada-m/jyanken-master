using UnityEngine;

public class EnemyHand : IEnemyHand
{
    Value.Hand stone = Value.Hand.Stone;
    Value.Hand scissors = Value.Hand.Scissors;
    Value.Hand paper = Value.Hand.Paper;

    // TODO 今のCPUはグーしか出さない
    public Value.Hand PickHand()
    {
        return stone;
    }
}
