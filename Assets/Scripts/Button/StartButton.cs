using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject handButtons;
    List<IObserver> observers = new List<IObserver>();
    readonly string updateText = "���̎���o�������߂Ă�������";

    public void OnClickButton()
    {
        handButtons.SetActive(true);
        menuButtons.SetActive(false);
        NotifyObservers();

    }
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
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
            o.Up(updateText);
        }
    }
}
