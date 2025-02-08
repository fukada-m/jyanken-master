using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
// ����񂯂�̌��ʂ�ێ����āA���ʂ��I�u�U�[�o�[�ɒʒm����
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

    // �S�Ă�observer���A�b�v�f�[�g����
    void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Up($"���Ȃ���{Result}�ł�");
        }
    }
}
