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
    [SerializeField]
    GameObject _resultButtonOBJ;
    [SerializeField]
    HandButtons _handButtons;
    [SerializeField]
    PonButton _ponButton;


    // テスト用の依存関係を注入するメソッド
    public void Initialize(
        GameObject h1,
        GameObject s,
        GameObject p1,
        GameObject r,
        HandButtons h2,
        PonButton p2
     )
    {
        _handButtonsOBJ = h1;
        _settingModal = s;
        _ponButtonOBJ = p1;
        _resultButtonOBJ = r;
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
        SetPlayerHand();
    }

    void HideObject()
    {
        _handButtonsOBJ.SetActive(false);
        _settingModal.SetActive(false);
        _ponButtonOBJ.SetActive(false);
        _resultButtonOBJ.SetActive(false);
    }
    void SetPlayerHand()
    {
        var hand = new Hand();
        _handButtons.Hand = hand;
        _ponButton.Hand = hand;
    }
}
