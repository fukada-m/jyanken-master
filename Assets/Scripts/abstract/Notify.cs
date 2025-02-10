using System.Collections.Generic;
using UnityEngine;

public abstract class Notify
{
    protected List<IObserver> observers = new List<IObserver>();
    public string Text { get; protected set; }

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }
    // 主にテストで使う
    public IObserver GetObserver(int i)
    {
        return observers[i];
    }

    // 全てのobserverをアップデートする
    protected void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Up(this);
        }
    }
}
