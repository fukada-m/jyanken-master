using UnityEngine;
using System.Collections;

public class PonButton : MonoBehaviour
{
    public virtual Hand Hand {  get; set; }
    public virtual IResult Result { get; set; }
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject ponButton;
    [SerializeField]
    GameObject resultbutton;
    IObserver messageText;
    Notify notify;
    ILogicJyanken logicJyanken;
    EnemyHand enemyHand;

    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify = new Notify();
        notify.AddObserver(messageText);
        logicJyanken = new LogicJyanken();
        enemyHand = new EnemyHand();
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(
        GameObject h1, 
        GameObject p, 
        GameObject r1,
        Notify n, 
        ILogicJyanken l, 
        EnemyHand e, 
        Hand h2, 
        IResult r2
    )
    {
        handButtons = h1;
        ponButton = p;
        resultbutton = r1;
        notify = n;
        logicJyanken = l;
        enemyHand = e;
        Hand = h2;
        Result = r2;
    }

    public void OnClickButton()
    {
        handButtons.SetActive(false);
        enemyHand.PickHand();
        var hand = Hand.ConvertHandToJapanese();
        notify.SetTextNotify($"相手は{hand}を選びました");
        Result.Current = logicJyanken.Judge(Hand.Current, enemyHand.Current);
        ponButton.SetActive(false);
        resultbutton.SetActive(true);
    }

}
