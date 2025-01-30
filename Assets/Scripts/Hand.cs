using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
// プレイヤーがどの手を出しているかについて責任を持つクラス

public class Hand : MonoBehaviour, IHand
{
    // プレイヤーの手の状態を表す
    public string Current { get; private set; }
    List<IObserver> observers = new List<IObserver>();

    // プレイヤーがグーを選んだ
    public void onClickStoneButton()
    {
        Current = "stone";
        NotifyObservers();
    }

    // プレイヤーがパーを選んだ
    public void onClickPaperButton()
    {
        Current = "paper";
        NotifyObservers();
    }

    // プレイヤーがチョキを選んだ
    public void onClickScissorsButton()
    {
        Current = "scissors";
        NotifyObservers();
    }

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    public IObserver GetObserver(int i)
    {
        return observers[i];
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
