using System.Collections.Generic;
using UnityEngine;

public abstract class Notify
{
    protected List<IObserver> observers = new List<IObserver>();
    public virtual string Text { get; protected set; }

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    // 主にテストで使う
    public IObserver GetObserver(int i)
    {
        return observers[i];
    }
    public abstract void GenerateText();

    // 全てのobserverをアップデートする
    protected void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Up(this);
        }
    }
}
