using TMPro;
using UnityEngine;

public interface IObserver
{
    void Initialize(TMP_Text t);
    // オブザーバーパターンのUpdate()のと名前が衝突してしまう。
    // TODO: 名前衝突を解決する
    void Up(Notify notify);

    string GetText();
}
