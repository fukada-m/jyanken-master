using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    GameObject _menuButtons;
    [SerializeField]
    GameObject _handButtons;
    Notify _notify;

    public void Initialize(GameObject m, GameObject h, Notify s)
    {
        _menuButtons = m;
        _handButtons = h;
        _notify = s;
    }

    public void OnClickButton()
    {
        _handButtons.SetActive(true);
        _menuButtons.SetActive(false);
        //_start.GenerateText();
        _notify.SetTextNotify("âΩÇÃéËÇèoÇ∑Ç©åàÇﬂÇƒÇ≠ÇæÇ≥Ç¢");

    }
    void Start()
    {
        _notify = new Notify();
    }
}
