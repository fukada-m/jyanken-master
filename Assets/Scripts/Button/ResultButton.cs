using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField]
    GameObject resultButtonOBJ;
    IObserver messageText;
    INotify notify;
    public IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notify = new Notify();
        resultButtonOBJ = GameObject.Find("ResultButton");
        messageText = resultButtonOBJ.GetComponent<IObserver>();
        notify.AddObserver(messageText);
    }

    public void Initialize(GameObject r1, INotify n, IResult r2)
    {
        resultButtonOBJ =  r1;
        notify = n;
        Result = r2;
    }

    public void OnClickButton()
    {
        notify.SetTextNotify($"���Ȃ���{Result.ConvertResultToJapanese(Result.Current)}�ł�");
        resultButtonOBJ.SetActive(false);
    }

}
