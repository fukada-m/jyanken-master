using UnityEngine;

public class ResultButton : MonoBehaviour
{
    IObserver messageText;
    Notify notify;
    public IResult Result { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify = new Notify();
        notify.AddObserver(messageText);
    }

    public void Initialize(Notify n)
    {
        notify = n;
    }

    public void OnClickButton()
    {

    }
}
