using UnityEngine;
using TMPro;

//　プレイヤーの出した手を観察して表示を変えるクラス
public class ObserverText : MonoBehaviour, IObserver
{
    [SerializeField]
    TMP_Text text;
    [SerializeField]
    GameManager gameManager;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "じゃんけんマスターへようこそ";
    }

    void TextUpdate(string t)
    {
        text.text = t;
    }

    // オブザーバーパターンのUpdate()のこと名前が衝突してしまう。
    // TODO: 名前衝突を解決する
     public void Up(Notify n)
    {
        TextUpdate(n.Text);
    }

    public string GetText()
    {
        return text.text;
    }
}
