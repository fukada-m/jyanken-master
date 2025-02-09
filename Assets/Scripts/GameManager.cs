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
        // TODO ���������p�̃I�u�W�F�N�g�����
        var handButtons = GameObject.Find("HandButtons");
        var hand =handButtons.GetComponent<IHand>();
        var startButton = GameObject.Find("StartButton").GetComponent<StartButton>();


        var observerText = GameObject.Find("ObserverText").GetComponent<IObserver>();
        hand.AddObserver( observerText );
        startButton.AddObserver( observerText );

        var settingModal = GameObject.Find("Setting");
        var ponButton = GameObject.Find("PonButton");

        // �Q�[���J�n���͔�A�N�e�B�u
        handButtons.SetActive( false );
        settingModal.SetActive( false );
        ponButton.SetActive( false );
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
