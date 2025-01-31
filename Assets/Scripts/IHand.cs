using UnityEngine;

public interface IHand
{
    GameManager.Sign Current { get; }
    void AddObserver(IObserver observer);
    IObserver GetObserver(int index);
}
