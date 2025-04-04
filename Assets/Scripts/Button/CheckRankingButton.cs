using UnityEngine;

public class CheckRankingButton : MonoBehaviour
{
    [SerializeField]
    Ranking ranking;
    IObserver messageText;
    INotify messageNotify;
    public IResult Result {  get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<ObserverText>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
    }

    public void OnclickButton()
    {
        ranking.CheckRanking(Result.WinCount);
        messageNotify.SetTextNotify("ƒ‰ƒ“ƒLƒ“ƒO‚Æ”äŠr’†...");
    }
    
}
