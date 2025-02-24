using UnityEngine;
using System.Collections;

public class PonButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject ponButton;
    [SerializeField]
    GameObject resultbutton;
    IObserver messageText;
    Notify notify;
    ILogicJyanken logicJyanken;
    IEnemyHand enemyHand;
    IResult result;
    public virtual IHand Hand {  get; set; }

    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify = new Notify();
        notify.AddObserver(messageText);
        logicJyanken = new LogicJyanken();
        enemyHand = new EnemyHand();
        result = new Result();
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(
        GameObject h1, 
        GameObject p, 
        GameObject r1,
        Notify n, 
        ILogicJyanken l, 
        IEnemyHand e, 
        IHand h2, 
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
        result = r2;
    }

    public void OnClickButton()
    {
        handButtons.SetActive(false);
        var enemyChoseHand = enemyHand.PickHand();
        var hand = Hand.ConvertHandToJapanese(enemyChoseHand);
        notify.SetTextNotify($"相手は{hand}を選びました");
        result.Current = logicJyanken.Judge(Hand.Current, enemyChoseHand);
        ponButton.SetActive(false);
        resultbutton.SetActive(true);
    }

}
