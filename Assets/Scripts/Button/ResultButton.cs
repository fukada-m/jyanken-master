using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField]
    GameObject resultButtonOBJ;
    [SerializeField]
    GameObject endButtonOBJ;
    [SerializeField]
    GameObject winCountTextOBJ;
    [SerializeField]
    GameObject againButtonOBJ;
    [SerializeField]
    GameObject checkRankingButton;
    IObserver messageText;
    IObserver winCountText;
    INotify messageNotify;
    INotify winCountNotify;
    public virtual IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<ObserverText>();
        // WinCountTextは最初非表示になっているので
        // 親オブジェクトのCanvasをたどって取得
        Transform parent = GameObject.Find("Canvas").transform;
        Transform child = parent.transform.Find("WinCountText");
        winCountTextOBJ = child.gameObject;
        winCountText = winCountTextOBJ.GetComponent<ObserverText>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
        winCountNotify = new Notify();
        winCountNotify.AddObserver(winCountText);
        
    }

    //テスト用の依存関係を注入するメソッド
    public void Initialize(
        GameObject r1,
        GameObject e,
        GameObject w,
        GameObject a,
        INotify n1,
        INotify n2,
        IResult r2
    )
    {
        resultButtonOBJ =  r1;
        endButtonOBJ = e;
        winCountTextOBJ = w;
        againButtonOBJ = a;
        messageNotify = n1;
        winCountNotify = n2;
        Result = r2;
    }

    public void OnClickButton()
    {
        // なぜかシナリオテストをするとnotifyがNullになるから処理を追加
        if (messageNotify == null)
        {
            Start();
        }
        messageNotify.SetTextNotify($"結果は{Result.ConvertResultToJapanese()}です");
        WinCountLogic();
        resultButtonOBJ.SetActive(false);
        endButtonOBJ.SetActive(true);
        winCountTextOBJ.SetActive(true);
        againButtonOBJ.SetActive(true);


        //負けかつランキングに登録できるときはの場合はランキング登録ボタンを表示する
        if (Result.Current == Value.Result.Lose)
        {
            checkRankingButton.SetActive(true);
        }

    }

    void WinCountLogic()
    {
        if (Result.Current == Value.Result.Win) Result.WinCount++;
        winCountNotify.SetTextNotify($"連勝数：{Result.WinCount}");
    }

}
