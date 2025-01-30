using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
// �v���C���[���ǂ̎���o���Ă��邩�ɂ��ĐӔC�����N���X

public class Hand : MonoBehaviour, IHand
{
    // �v���C���[�̎�̏�Ԃ�\��
    public string Current { get; private set; }
    List<IObserver> observers = new List<IObserver>();

    // �v���C���[���O�[��I��
    public void onClickStoneButton()
    {
        Current = "stone";
        NotifyObservers();
    }

    // �v���C���[���p�[��I��
    public void onClickPaperButton()
    {
        Current = "paper";
        NotifyObservers();
    }

    // �v���C���[���`���L��I��
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

    // �S�Ă�observer���A�b�v�f�[�g����
    void NotifyObservers()
    {
        foreach (var o in observers)
        {
            o.Up(this);
        }
    }
   
}
