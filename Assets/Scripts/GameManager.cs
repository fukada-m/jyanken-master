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
        // TODO ���������p�̃I�u�W�F�N�g�����
        var handButtons = GameObject.Find("HandButtons");
        hand = handButtons.GetComponent<IHand>();
        var startButton = GameObject.Find("StartButton").GetComponent<StartButton>();


        var observerTextObj = GameObject.Find("ObserverText");
        var ot = observerTextObj.GetComponent<IObserver>();
        hand.AddObserver( ot );
        startButton.AddObserver( ot );

        var setting = GameObject.Find("Setting");

        // �Q�[���J�n���͔�A�N�e�B�u
        handButtons.SetActive( false );
        setting.SetActive( false );
    }

    public string ConvertSignToJapanese(Sign sign)
    {
        return sign switch
        {
            GameManager.Sign.Stone => "�O�[",
            GameManager.Sign.Scissors => "�`���L",
            GameManager.Sign.Paper => "�p�[",
            _ => "�G���[" // �f�t�H���g�P�[�X
        };
    }
    
}
