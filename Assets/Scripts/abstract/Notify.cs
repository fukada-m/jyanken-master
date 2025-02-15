using System.Collections.Generic;
using UnityEngine;

public class Notify : INotify
{
    protected List<IObserver> observers = new List<IObserver>();
    public virtual string Text { get;　private set; }

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    // 主にテストで使う
    public IObserver GetObserver(int i)
    {
        return observers[i];
    }

    // テキストがセットされるとオブザーバーが更新される
    public virtual void SetTextNotify(string s)
    {
        Text = s;
        NotifyObservers();
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
