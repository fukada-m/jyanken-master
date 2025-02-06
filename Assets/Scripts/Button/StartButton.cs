using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject handButtons;
    List<IObserver> observers = new List<IObserver>();

    public void onClick()
    {
        menuButtons.SetActive(false);
        handButtons.SetActive(true);
    }
    public void AddObserver(IObserver observer)
    {

    }

    public IObserver GetObserver(int i)
    {
        return observers[i];
    }
}
