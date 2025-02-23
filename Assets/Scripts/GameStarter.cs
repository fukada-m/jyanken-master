using UnityEngine;
/* 
 * 最初の準備でやること 
 * - 使わないボタンの非表示
 * - Signを注入
*/
public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameObject _handButtonsOBJ;
    [SerializeField]
    GameObject _settingModal;
    [SerializeField]
    GameObject _ponButtonOBJ;
    HandButtons _handButtons;
    PonButton _ponButton;

    // テスト用の依存関係を注入するメソッド
    public void Initialize(
        GameObject h1,
        GameObject s,
        GameObject p1,
        HandButtons h2,
        PonButton p2
     )
    {
        _handButtonsOBJ = h1;
        _settingModal = s;
        _ponButtonOBJ = p1;
        _handButtons = h2;
        _ponButton = p2;

    }

    // テスト内でStart()を実行するためのpublicなメソッド
    public void TestStart()
    {
        Start();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideObject();
        SetSign();
    }

    void HideObject()
    {
        _handButtonsOBJ.SetActive(false);
        _settingModal.SetActive(false);
        _ponButtonOBJ.SetActive(false);
    }
    void SetSign()
    {
        var hand = new Hand();
        _handButtons.Hand = hand;
        _ponButton.Hand = hand;
    }
}
