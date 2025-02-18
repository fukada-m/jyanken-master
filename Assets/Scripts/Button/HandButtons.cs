using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    [SerializeField]
    GameObject _ponButton;
    IObserver _messageText;
    Notify _notify;
    ISign _sign;

    void Start()
    {
        _sign = new Sign();
        _notify = new Notify();
        _messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        _notify.AddObserver(_messageText);
    }

    // テストの依存関係を注入するメソッド
    public void Initialize(GameObject p, IObserver o, Notify n, ISign s)
    {
        _ponButton = p;
        _messageText = o;
        _notify = n;
        _sign = s;
    }

    // プレイヤーがグーを選んだ
    public void OnClickStoneButton()
    {
        _sign.Current = Sign.Hand.Stone;
        SetHand(_sign);
        _ponButton.SetActive(true);
    }

    // プレイヤーがパーを選んだ
    public void OnClickPaperButton()
    {
        _sign.Current = Sign.Hand.Paper;
        SetHand(_sign);
        _ponButton.SetActive(true);
    }

    // プレイヤーがチョキを選んだ
    public void OnClickScissorsButton()
    {
        _sign.Current = Sign.Hand.Scissors;
        SetHand(_sign);
        _ponButton.SetActive(true);
    }

    void SetHand(ISign sign)
    {
        var text = $"あなたは{_sign.ConvertHandToJapanese(sign.Current)}を選んでいます";
        _notify.SetTextNotify(text);
    }
}
