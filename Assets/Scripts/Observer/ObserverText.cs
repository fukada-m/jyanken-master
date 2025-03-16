using UnityEngine;
using TMPro;

//　プレイヤーの出した手を観察して表示を変えるクラス
public class ObserverText : MonoBehaviour, IObserver
{
    [SerializeField]
    TMP_Text _text;
    [SerializeField]
    string firstText;

    // テスト用の依存関係を注入するメソッド
    public void Initialize(TMP_Text t)
    {
        _text = t;
    }

     public void Up(Notify n)
    {
        TextUpdate(n.Text);
    }

    // テストでテキストの内容を取得するのに用いる
    public string GetText()
    {
        return _text.text;
    }

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text.text = firstText;
    }

    void TextUpdate(string t)
    {
        _text.text = t;
    }


}
