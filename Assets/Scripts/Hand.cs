using UnityEngine;
using System.Collections.Generic;
// �v���C���[���ǂ̎���o���Ă��邩�ɂ��ĐӔC�����N���X

public class Hand : MonoBehaviour, IHand
{
    // �v���C���[�̎�̏�Ԃ�\��
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

    // �S�Ă�observer���A�b�v�f�[�g����
    void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Up(this);
        }
    }
   
}
