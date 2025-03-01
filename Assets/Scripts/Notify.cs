using System.Collections.Generic;
using UnityEngine;

public class Notify : INotify
{
    protected List<IObserver> observers = new List<IObserver>();
    public virtual string Text { get;�@private set; }

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    // ��Ƀe�X�g�Ŏg��
    public IObserver GetObserver(int i)
    {
        return observers[i];
    }

    // �e�L�X�g���Z�b�g�����ƃI�u�U�[�o�[���X�V�����
    public virtual void SetTextNotify(string s)
    {
        Text = s;
        NotifyObservers();
    }

    // �S�Ă�observer���A�b�v�f�[�g����
    protected void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Up(this);
        }
    }
}
