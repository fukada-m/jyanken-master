using UnityEngine;

public class PonButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    IObserver messageText;
    Notify notify;
    ILogicJyanken logicJyanken;
    IEnemyHand enemyHand;

    void Start()
    {
        logicJyanken = new LogicJyanken(); 
        enemyHand = new EnemyHand();
        notify = new Notify();
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify.AddObserver(messageText);
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject h, IObserver m, Notify n, ILogicJyanken l, IEnemyHand e)
    {
        handButtons = h;
        messageText = m;
        notify = n;
        logicJyanken = l;
        enemyHand = e;
    }

    public void OnClickButton()
    {
        handButtons.SetActive(false);
        var enemyChoseHand = enemyHand.PickHand();
        notify.SetTextNotify($"相手は{enemyChoseHand}を選びました");
        var result = logicJyanken.Judge(Sign.Hand.Scissors, enemyChoseHand);
    }

}
