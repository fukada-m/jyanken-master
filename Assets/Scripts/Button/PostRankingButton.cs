using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PostRankingButton : MonoBehaviour
{
    [SerializeField]
    Ranking ranking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnClickButton()
    {
        ranking.PostRanking();
    }
}

