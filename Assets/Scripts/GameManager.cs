using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Hand hand;
    enum Sign
    {
        Stone,
        Scissors,
        Paper
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        var hoObj = GameObject.Find("ObserverText");
        var ho = hoObj.GetComponent<IObserver>();
        hand.AddObserver( ho );
    }
}
