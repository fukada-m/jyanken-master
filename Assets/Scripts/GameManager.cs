using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    IHand hand;
    public enum Sign
    {
        Stone,
        Scissors,
        Paper,
        Error
    }

    public enum Result
    {
        Draw,
        WIn,
        Lose,
        Error
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var handButtons = GameObject.Find("HandButtons");
        hand = handButtons.GetComponent<IHand>();

        var observerTextObj = GameObject.Find("ObserverText");
        var ot = observerTextObj.GetComponent<IObserver>();
        hand.AddObserver( ot );
    }

    public string ConvertSignToJapanese(Sign sign)
    {
        return sign switch
        {
            GameManager.Sign.Stone => "グー",
            GameManager.Sign.Scissors => "チョキ",
            GameManager.Sign.Paper => "パー",
            _ => "エラー" // デフォルトケース
        };
    }
    
}
