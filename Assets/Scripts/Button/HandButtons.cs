using System.Linq;
using UnityEngine;

public class HandButtons : MonoBehaviour
{
    Notify _notify;
    ISign _sign;

    void Start()
    {
        _sign = new Sign();
        _notify = new Notify();
    }

    // テストの依存関係を注入するメソッド
    public void Initialize(Notify n, ISign s)
    {
        _notify = n;
        _sign = s;
    }

    // プレイヤーがグーを選んだ
    public void OnClickStoneButton()
    {
        _sign.Current = Sign.Hand.Stone;
        SetHand(_sign);
    }

    // プレイヤーがパーを選んだ
    public void OnClickPaperButton()
    {
        _sign.Current = Sign.Hand.Paper;
        SetHand(_sign);
    }

    // プレイヤーがチョキを選んだ
    public void OnClickScissorsButton()
    {
        _sign.Current = Sign.Hand.Scissors;
        SetHand(_sign);
    }

    void SetHand(ISign sign)
    {
        var text = $"あなたは{_sign.ConvertHandToJapanese(sign.Current)}を選んでいます";
        _notify.SetTextNotify(text);
    }
}
