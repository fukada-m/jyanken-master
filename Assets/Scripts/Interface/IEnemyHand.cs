using UnityEngine;

public interface IEnemyHand
{
    Value.Hand Current {  get; set; }
    void PickHand();
}
