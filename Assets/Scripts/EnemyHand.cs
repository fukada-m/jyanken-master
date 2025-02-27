using UnityEngine;

public class EnemyHand : IEnemyHand
{
    Value.Hand stone = Value.Hand.Stone;
    Value.Hand scissors = Value.Hand.Scissors;
    Value.Hand paper = Value.Hand.Paper;

    // TODO 今のCPUはグーしか出さない
    public Value.Hand PickHand()
    {
        // 0, 1, 2のどれか
        int num = Random.Range(0, 3);
        return num switch
        {
            0 => stone,
            1 => scissors,
            2 => paper,
            _=> Value.Hand.Error //デフォルトケース
        };
    }
}
