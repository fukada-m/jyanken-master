using UnityEngine;

public class AgainButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject againButtonOBJ;
    [SerializeField]
    GameObject endButtonOBJ;
    [SerializeField]
    GameObject checkRankingButtonOBJ;
    Notify messageNotify;
    Notify winCountNotify;
    IObserver messageText;
    IObserver winCountText;
    public virtual IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
        // WinCountTextは最初非表示になっているので
        // 親オブジェクトのCanvasをたどって取得
        Transform parent = GameObject.Find("Canvas").transform;
        Transform child = parent.transform.Find("WinCountText");
        var winCountTextOBJ = child.gameObject;
        winCountText = winCountTextOBJ.GetComponent<ObserverText>();
        winCountNotify = new Notify();
        winCountNotify.AddObserver(winCountText);
    }

    // テストの依存関係を注入するメソッド
    public void Initialize(GameObject h, GameObject a, GameObject e, Notify n)
    {
        handButtons = h;
        againButtonOBJ = a;
        endButtonOBJ = e;
        messageNotify = n;
    }

    public void OnClickButton()
    {

        // ハンドボタンズを表示
        handButtons.SetActive(true);
        // 自身を非表示
        againButtonOBJ.SetActive(false);
        // エンドボタンを非表示
        endButtonOBJ.SetActive(false);
        // テキストメッセージを"何の手を出すか決めてください"に変更
        messageNotify.SetTextNotify("何の手を出すか決めてください");
        // 直前に負けていた場合は連勝数を0にする
        if (Result.Current == Value.Result.Lose)
        {
            Result.WinCount = 0;
            winCountNotify.SetTextNotify($"連勝数：{Result.WinCount}");
        }
        // ランキング登録ボタンは非表示
        checkRankingButtonOBJ.SetActive(false);
    }
}
