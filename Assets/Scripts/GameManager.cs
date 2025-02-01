using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
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
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        var handButtons = objects.FirstOrDefault(o => o.name == "HandButtons");
        hand = handButtons.GetComponent<Hand>();

        var observerTextObj = GameObject.Find("ObserverText");
        var ot = observerTextObj.GetComponent<IObserver>();
        hand.AddObserver( ot );
    }

    public static string ConvertSignToJapanese(Sign sign)
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
