using UnityEngine;

public interface INotify
{
    void AddObserver(IObserver o);
    IObserver GetObserver(int i);
    void SetTextNotify(string s);
}
