using UnityEngine;

public class PonButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject ponButton;
    IObserver messageText;
    Notify notify;
    ILogicJyanken logicJyanken;
    IEnemyHand enemyHand;
    public IHand Hand {  get; set; }

    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify = new Notify();
        notify.AddObserver(messageText);
        logicJyanken = new LogicJyanken();
        enemyHand = new EnemyHand();
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject h1, GameObject p, IObserver m, Notify n, ILogicJyanken l, IEnemyHand e, IHand h2)
    {
        handButtons = h1;
        ponButton = p;
        messageText = m;
        notify = n;
        logicJyanken = l;
        enemyHand = e;
        Hand = h2;
    }

    public void OnClickButton()
    {
        handButtons.SetActive(false);
        ponButton.SetActive(false);
        var enemyChoseHand = enemyHand.PickHand();
        var hand = Hand.ConvertHandToJapanese(enemyChoseHand);
        notify.SetTextNotify($"相手は{hand}を選びました");
        var result = logicJyanken.Judge(Hand.Current, enemyChoseHand);
    }

}
