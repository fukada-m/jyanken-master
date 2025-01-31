using UnityEngine;
using TMPro;

//　プレイヤーの出した手を観察して表示を変えるクラス
public class ObserverText : MonoBehaviour, IObserver
{
    [SerializeField] TMP_Text text;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "出す手を決めてください";
    }

    void TextUpdate(GameManager.Sign sign)
    {
        string s = sign switch
        {
            GameManager.Sign.Stone => "グー",
            GameManager.Sign.Scissors => "チョキ",
            GameManager.Sign.Paper => "パー",
            _ => "エラー" // デフォルトケース
        };

        text.text = $"{s}を選んでいます";
    }

    // オブザーバーパターンのUpdate()のこと名前が衝突してしまう。
    // TODO: 名前衝突を解決する
     public void Up(IHand h)
    {
        TextUpdate(h.Current);
    }
}
