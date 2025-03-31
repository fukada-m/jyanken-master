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
    [SerializeField]
    GameObject _rankingButton;
    IObserver _messageText;
    Notify _notify;

    public void Initialize(GameObject m, GameObject h, GameObject r, IObserver o, Notify s)
    {
        _menuButtons = m;
        _handButtons = h;
        _rankingButton = r;
        _messageText = o;
        _notify = s;
    }

    public void OnClickButton()
    {
        _handButtons.SetActive(true);
        _menuButtons.SetActive(false);
        _rankingButton.SetActive(false);
        _notify.SetTextNotify("âΩÇÃéËÇèoÇ∑Ç©åàÇﬂÇƒÇ≠ÇæÇ≥Ç¢");

    }
    void Start()
    {
        _notify = new Notify();
        _messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        _notify.AddObserver(_messageText);
    }
}
