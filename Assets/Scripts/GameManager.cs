using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
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
        // TODO 初期処理用のオブジェクトを作る
        var handButtons = GameObject.Find("HandButtons");
        var hand =handButtons.GetComponent<IHand>();
        var startButton = GameObject.Find("StartButton").GetComponent<StartButton>();


        var observerText = GameObject.Find("ObserverText").GetComponent<IObserver>();
        hand.AddObserver( observerText );
        startButton.AddObserver( observerText );

        var settingModal = GameObject.Find("Setting");
        var ponButton = GameObject.Find("PonButton");

        // ゲーム開始時は非アクティブ
        handButtons.SetActive( false );
        settingModal.SetActive( false );
        ponButton.SetActive( false );
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
