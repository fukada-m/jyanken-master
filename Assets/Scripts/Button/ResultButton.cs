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
        notify = new Notify();
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
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
        notify.SetTextNotify($"結果は{Result.ConvertResultToJapanese(Result.Current)}です");
        resultButtonOBJ.SetActive(false);
    }

}
