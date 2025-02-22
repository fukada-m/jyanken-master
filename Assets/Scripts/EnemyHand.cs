using UnityEngine;

public class EnemyHand : IEnemyHand
{
    Sign.Hand stone = Sign.Hand.Stone;
    Sign.Hand scissors = Sign.Hand.Scissors;
    Sign.Hand paper = Sign.Hand.Paper;

    // TODO ¡‚ÌCPU‚ÍƒO[‚µ‚©o‚³‚È‚¢
    public Sign.Hand PickHand()
    {
        return stone;
    }
}
