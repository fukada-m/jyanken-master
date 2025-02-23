using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    GameObject _ponButton;
    IObserver _messageText;
    Notify _notify;
    public virtual IHand Hand {  get; set; }

    void Start()
    {
        _notify = new Notify();
        _messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        _notify.AddObserver(_messageText);
    }

    // テストの依存関係を注入するメソッド
    public void Initialize(GameObject p, IObserver o, Notify n, Hand s)
    {
        _ponButton = p;
        _messageText = o;
        _notify = n;
        Hand = s;
    }



    // プレイヤーがグーを選んだ
    public void OnClickStoneButton()
    {
        Hand.Current = Value.Hand.Stone;
        SetHand(Hand);
        _ponButton.SetActive(true);
    }

    // プレイヤーがパーを選んだ
    public void OnClickPaperButton()
    {
        Hand.Current = Value.Hand.Paper;
        SetHand(Hand);
        _ponButton.SetActive(true);
    }

    // プレイヤーがチョキを選んだ
    public void OnClickScissorsButton()
    {
        Hand.Current = Value.Hand.Scissors;
        SetHand(Hand);
        _ponButton.SetActive(true);
    }

    void SetHand(IHand Hand)
    {
        var text = $"あなたは{Hand.ConvertHandToJapanese(Hand.Current)}を選んでいます";
        _notify.SetTextNotify(text);
    }
}
