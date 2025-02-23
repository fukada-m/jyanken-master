using UnityEngine;

public class EnemyHand : IEnemyHand
{
    Value.Hand stone = Value.Hand.Stone;
    Value.Hand scissors = Value.Hand.Scissors;
    Value.Hand paper = Value.Hand.Paper;

    // TODO ç°ÇÃCPUÇÕÉOÅ[ÇµÇ©èoÇ≥Ç»Ç¢
    public Value.Hand PickHand()
    {
        return stone;
    }
}
