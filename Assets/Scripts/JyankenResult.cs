using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
// じゃんけんの結果を保持して、結果をオブザーバーに通知する
public class JyankenResult : IJyankenResult
{
    public GameManager.Result Result { get; private set; }
    List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    public IObserver GetObserver(int i)
    {
        return observers[i];
    }

    public void SetResult(GameManager.Result result)
    {
        Result = result;
        NotifyObservers();
    }

    // 全てのobserverをアップデートする
    void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Up($"あなたの{Result}です");
        }
    }
}
