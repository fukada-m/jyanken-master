using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField]
    GameObject resultButtonOBJ;
    IObserver messageText;
    INotify notify;
    public virtual IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify = new Notify();
        notify.AddObserver(messageText);
    }

    //テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject r1, INotify n, IResult r2)
    {
        resultButtonOBJ =  r1;
        notify = n;
        Result = r2;
    }

    public void OnClickButton()
    {
        // なぜかシナリオテストをするとnotifyがNullになるから処理を追加
        if (notify == null)
        {
            Start();
        }
        notify.SetTextNotify($"結果は{Result.ConvertResultToJapanese()}です");
        resultButtonOBJ.SetActive(false);
    }

}
