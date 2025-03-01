using UnityEngine;

public class EnemyHand : IEnemyHand
{
    public Value.Hand Current {  get; set; }

    Value.Hand stone = Value.Hand.Stone;
    Value.Hand scissors = Value.Hand.Scissors;
    Value.Hand paper = Value.Hand.Paper;

    // TODO 今のCPUはグーしか出さない
    public void PickHand()
    {
        // 0, 1, 2のどれかをランダムに生成する
        int num = Random.Range(0, 3);

        switch(num)
        {
            case 0:
                Current = stone; break;
            case 1:
                Current = scissors; break;
            case 2:
                Current = paper; break;
            default:
                Current = Value.Hand.Error; break;
        };
    }
}
