using UnityEngine;

public class EnemyHand : IEnemyHand
{
    GameManager.Sign stone = GameManager.Sign.Stone;
    GameManager.Sign scissors = GameManager.Sign.Scissors;
    GameManager.Sign paper = GameManager.Sign.Paper;

    public GameManager.Sign PickHand()
    {
        return stone;
    }
}
