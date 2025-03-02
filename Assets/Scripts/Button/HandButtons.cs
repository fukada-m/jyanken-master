using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    GameObject _ponButton;
    IObserver _messageText;
    Notify _notify;
    public virtual PlayerHand PlayerHand {  get; set; }

    void Start()
    {
        _notify = new Notify();
        _messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        _notify.AddObserver(_messageText);
    }

    // テストの依存関係を注入するメソッド
    public void Initialize(GameObject p, IObserver o, Notify n, PlayerHand ph)
    {
        _ponButton = p;
        _messageText = o;
        _notify = n;
        PlayerHand = ph;
    }



    // プレイヤーがグーを選んだ
    public void OnClickStoneButton()
    {
        PlayerHand.Current = Value.Hand.Stone;
        SetHand();
        _ponButton.SetActive(true);
    }

    // プレイヤーがパーを選んだ
    public void OnClickPaperButton()
    {
        PlayerHand.Current = Value.Hand.Paper;
        SetHand();
        _ponButton.SetActive(true);
    }

    // プレイヤーがチョキを選んだ
    public void OnClickScissorsButton()
    {
        PlayerHand.Current = Value.Hand.Scissors;
        SetHand();
        _ponButton.SetActive(true);
    }

    void SetHand()
    {
        var text = $"あなたは{PlayerHand.ConvertHandToJapanese()}を選んでいます";
        _notify.SetTextNotify(text);
    }
}
