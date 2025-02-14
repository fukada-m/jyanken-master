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
    Notify _start;

    public void Initialize(GameObject m, GameObject h, Notify s)
    {
        _menuButtons = m;
        _handButtons = h;
        _start = s;
    }

    public void OnClickButton()
    {
        _handButtons.SetActive(true);
        _menuButtons.SetActive(false);
        _start.GenerateText();

    }
    void Start()
    {
        _start = new Start();
    }
}
