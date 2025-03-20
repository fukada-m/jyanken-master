using UnityEngine;

public class AgainButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject againButtonOBJ;
    [SerializeField]
    GameObject endButtonOBJ;
    Notify notify;
    IObserver messageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        notify = new Notify();
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify.AddObserver(messageText);
    }

    // テストの依存関係を注入するメソッド
    public void Initialize(GameObject h, GameObject a, GameObject e, Notify n)
    {
        handButtons = h;
        againButtonOBJ = a;
        endButtonOBJ = e;
        notify = n;
    }

    public void OnClickButton()
    {
        // ハンドボタンズを表示
        handButtons.SetActive(true);
        // 自身を非表示
        againButtonOBJ.SetActive(false);
        // エンドボタンを非表示
        endButtonOBJ.SetActive(false);
        // テキストメッセージを"何の手を出すか決めてください"に変更
        notify.SetTextNotify("何の手を出すか決めてください");
    }
}
