using UnityEngine;

public class CheckRankingButton : MonoBehaviour
{
    [SerializeField]
    Ranking ranking;
    [SerializeField]
    GameObject againButton;
    [SerializeField]
    GameObject endButton;
    [SerializeField]
    GameObject postRankingButton;
    [SerializeField]
    GameObject inputNameField;
    IObserver messageText;
    INotify messageNotify;
    PostRankingFlag postRankingFlag;
    public IResult Result {  get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<ObserverText>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
        postRankingFlag = new PostRankingFlag();
    }
    void Update()
    {
        // フラグがオンの時はランキングを更新可能
        if (postRankingFlag.Flag ==2)
        {
            messageNotify.SetTextNotify("おめでとう!! ランキング投稿可能");
            postRankingButton.SetActive(true);
            inputNameField.SetActive(true);
            postRankingFlag.Flag = 0;
        }
        if (postRankingFlag.Flag == 1)
        {
            messageNotify.SetTextNotify("ざんねん。ランキング更新ならず");
            endButton.SetActive(true);
            againButton.SetActive(true);
            postRankingFlag .Flag = 0;
        }

    }

    public void OnclickButton()
    {
        messageNotify.SetTextNotify("ランキングと比較中...");
        ranking.CheckRanking(Result.WinCount, postRankingFlag);
        endButton.SetActive(false);
        againButton.SetActive(false);
    }
    
}

// 0はボタン押下前
// 1はランキング更新不可
// 2はランキング更新可能
public class PostRankingFlag
{
    public int Flag { get; set; }
    public PostRankingFlag()
    {
        Flag = 0;
    }
}
