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
        
        var s = GameManager.ConvertSignToJapanese(sign);

        text.text = $"{s}を選んでいます";
    }

    // オブザーバーパターンのUpdate()のこと名前が衝突してしまう。
    // TODO: 名前衝突を解決する
     public void Up(IHand h)
    {
        TextUpdate(h.Current);
    }
}
