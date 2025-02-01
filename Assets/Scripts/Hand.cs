using UnityEngine;
using System.Collections.Generic;
// プレイヤーがどの手を出しているかについて責任を持つクラス

public class Hand : MonoBehaviour, IHand
{
    // プレイヤーの手の状態を表す
    public GameManager.Sign Current { get; private set; }
    List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    public IObserver GetObserver(int i)
    {
        return observers[i];
    }

    public void SetCurrent(GameManager.Sign sign)
    {
        Current = sign;
        NotifyObservers();
    }

    // 全てのobserverをアップデートする
    void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Up(this);
        }
    }
   
}
